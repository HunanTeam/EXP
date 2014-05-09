using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ExpApp.Web.Framework.Common;
using ExpApp.Web.Framework.Extension.Filters;
using ExpApp.Site.Common.Models;
using System.Linq.Expressions;
using Exp.Tool.Helpers;
using ExpApp.Services.Sys;
using ExpApp.Domain.Models.Sys;
using ExpApp.Site.Models.Authen.Role;
using Exp.Core;
using ExpApp.Site.Models.Authen.RoleModulePermission;




namespace ExpApp.Admin.Controllers
{

    public class RoleController : AdminController
    {
        public RoleController(IUserService userService, IRoleService roleService,
            IModuleService moduleService, IPermissionService permissionService,
            IModulePermissionService modulePermissionService, IRoleModulePermissionService roleModulePermissionService)
        {
            this.UserService = userService;
            this.RoleService = roleService;
            this.ModuleService = moduleService;
            this.PermissionService = permissionService;
            this.ModulePermissionService = modulePermissionService;
            this.RoleModulePermissionService = roleModulePermissionService;
        }

        #region 属性

        public IUserService UserService { get; set; }


        public IRoleService RoleService { get; set; }


        public IModuleService ModuleService { get; set; }


        public IPermissionService PermissionService { get; set; }


        public IModulePermissionService ModulePermissionService { get; set; }


        public IRoleModulePermissionService RoleModulePermissionService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
            var model = new RoleModel();
            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
            int total = RoleService.Roles.Count(t => t.IsDeleted == false);

            //构建查询表达式
            var expr = BuildSearchCriteria();

            var filterResult = RoleService.Roles.Where(expr).Select(t => new RoleModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                OrderSort = t.OrderSort,
                Enabled = t.Enabled
            }).OrderBy(t => t.OrderSort).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.Name,
                                 c.Description,
                                 c.OrderSort.ToString(),                                
                                 c.EnabledText,
                                 c.Id.ToString()
                             };

            return Json(new
            {
                sEcho = param.sEcho,
                iDisplayStart = param.iDisplayStart,
                iTotalRecords = total,
                iTotalDisplayRecords = total,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        #region 构建查询表达式
        /// <summary>
        /// 构建查询表达式
        /// </summary>
        /// <returns></returns>
        private Expression<Func<Role, Boolean>> BuildSearchCriteria()
        {
            DynamicLambdaHelper<Role> bulider = new DynamicLambdaHelper<Role>();
            Expression<Func<Role, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["Name"]))
            {
                var data = Request["Name"].Trim();
                Expression<Func<Role, Boolean>> tmp = t => t.Name.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? true : false;
                Expression<Func<Role, Boolean>> tmp = t => t.Enabled == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }

            Expression<Func<Role, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

        public ActionResult Create()
        {
            var model = new RoleModel();
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Create(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                this.CreateBaseData<RoleModel>(model);
                OperationResult result = RoleService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    return PartialView(model);
                }
            }
            else
            {
                return PartialView(model);
            }
        }

        public ActionResult Edit(int Id)
        {
            var model = new RoleModel();
            var entity = RoleService.Roles.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new RoleModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    OrderSort = entity.OrderSort,
                    Enabled = entity.Enabled
                };
            }
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Edit(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                this.UpdateBaseData<RoleModel>(model);
                OperationResult result = RoleService.Update(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    return PartialView(model);
                }
            }
            else
            {
                return PartialView(model);
            }
        }

        public ActionResult SetPermission(int Id)
        {
            //角色 - 菜单
            var model = new RoleSelectedModuleModel();

            #region 角色
            var role = RoleService.Roles.First(t => t.Id == Id);
            model.RoleId = role.Id;
            model.RoleName = role.Name;
            #endregion

            #region 菜单
            //菜单列表
            model.ModuleDataList = ModuleService.Modules.Where(t => t.IsMenu == true && t.IsDeleted == false && t.Enabled == true)
                                .Select(t => new ModuleModel
                                {
                                    ModuleId = t.Id,
                                    ParentId = t.ParentId,
                                    ModuleName = t.Name,
                                    Code = t.Code,
                                }).OrderBy(t => t.Code).ToList();

            //选中菜单
            var selectedModule = RoleModulePermissionService.RoleModulePermissions.Where(t => t.RoleId == Id && t.IsDeleted == false).Select(t => t.ModuleId).ToList();

            //对比菜单
            foreach (var item in model.ModuleDataList)
            {
                if (selectedModule.Contains(item.ModuleId))
                {
                    //选中此菜单
                    item.Selected = true;
                }
            }
            #endregion

            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult SetPermission(int roleId, string isSet, string newModulePermission)
        {
            OperationResult result = new OperationResult(OperationResultType.Success, "授权成功");
            if (isSet == "0")
            {
                result = new OperationResult(OperationResultType.NoChanged, "请选择按钮权限");
            }
            else
            {
                //选中的模块权限
                var oldModulePermissionList = RoleModulePermissionService.RoleModulePermissions.Where(t => t.RoleId == roleId && t.IsDeleted == false)
                                                .Select(t => new RoleModulePermissionModel
                                                {
                                                    RoleId = t.RoleId,
                                                    ModuleId = t.ModuleId,
                                                    PermissionId = t.PermissionId
                                                }).ToList();

                var newModulePermissionList = JsonConvert.DeserializeObject<List<RoleModulePermissionModel>>(newModulePermission);
                var sameModulePermissionList = oldModulePermissionList.Intersect(newModulePermissionList);
                var addModulePermissionList = newModulePermissionList.Except(sameModulePermissionList);
                var removeModulePermissionList = oldModulePermissionList.Except(sameModulePermissionList);

                result = RoleModulePermissionService.SetRoleModulePermission(roleId, addModulePermissionList, removeModulePermissionList);
            }
            return Json(result);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult GetPermission(int roleId, string selectedModules)
        {
            //选中模块
            List<int> selectedModuleId = new List<int>();
            if (!string.IsNullOrWhiteSpace(selectedModules))
            {
                string[] strSelectedModules = selectedModules.Split(',');
                foreach (var Id in strSelectedModules)
                {
                    selectedModuleId.Add(Convert.ToInt32(Id));
                }
            }
           

            //权限列表
            var model = new RoleSelectedPermissionModel();

            model.HeaderPermissionList = PermissionService.Permissions.Where(t => t.IsDeleted == false && t.Enabled == true)
                                                        .OrderBy(t => t.OrderSort)
                                                        .Select(t => new PermissionModel
                                                        {
                                                            PermissionId = t.Id,
                                                            PermissionName = t.Name,
                                                            OrderSort = t.OrderSort
                                                        }).ToList();

            //权限列表 (从选中的菜单获取)
            foreach (var moduleId in selectedModuleId.Distinct())
            {
                
                var module = ModuleService.Modules.FirstOrDefault(t => t.Id == moduleId);

                var modulePermissionModel = new ModulePermissionModel
                {
                    ModuleId = module.Id,
                    ParentId = module.ParentId,
                    ModuleName = module.Name,
                    Code = module.Code
                };

                //所有权限列表
                foreach (var permission in model.HeaderPermissionList)
                {
                    modulePermissionModel.PermissionDataList.Add(new PermissionModel
                    {
                        PermissionId = permission.PermissionId,
                        PermissionName = permission.PermissionName,
                        OrderSort = permission.OrderSort,
                    });
                }

                //模块包含的按钮
                var modulePermission = ModulePermissionService.ModulePermissions.Where(t => t.ModuleId == moduleId && t.IsDeleted == false).ToList();
                var selectedModulePermission = RoleModulePermissionService.RoleModulePermissions.Where(t => t.RoleId == roleId && t.ModuleId == moduleId && t.IsDeleted == false);

                if (module.ChildModule.Count > 0 && selectedModulePermission.Count() > 0)
                {
                    modulePermissionModel.Selected = true;
                }

                foreach (var mp in modulePermission)
                {
                    var permission = PermissionService.Permissions.FirstOrDefault(t => t.Id == mp.PermissionId);

                    foreach (var p in modulePermissionModel.PermissionDataList)
                    {
                        if (p.PermissionId == permission.Id)
                        {
                            //设置Checkbox可用
                            p.Enabled = true;
                            //设置选中
                            var rmp = RoleModulePermissionService.RoleModulePermissions.FirstOrDefault(t => t.RoleId == roleId && t.ModuleId == moduleId && t.PermissionId == permission.Id && t.IsDeleted == false);
                            if (rmp != null)
                            {
                                //设置父节点选中
                                modulePermissionModel.Selected = true;
                                p.Selected = true;
                            }
                        }
                    }

                }
                model.ModulePermissionDataList.Add(modulePermissionModel);
            }

            //权限按照Code排序
            model.ModulePermissionDataList = model.ModulePermissionDataList.OrderBy(t => t.Code).ToList();

            return PartialView("Permission", model);
        }

        [AdminOperateLog]
        public ActionResult Delete(int Id)
        {
            OperationResult result = RoleService.Delete(Id);
            return Json(result);
        }
    }
}