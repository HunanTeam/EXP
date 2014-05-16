using Exp.Core;
using Exp.Tool.Helpers;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services.Sys;
using ExpApp.Site.Common.Models;
using ExpApp.Site.Models.Authen.User;
using ExpApp.Web.Framework.Common;
using ExpApp.Web.Framework.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;



namespace ExpApp.Admin.Controllers
{

    public class UserController : AdminController
    {

        public UserController(IUserService userService, IRoleService roleService)
        {
            this.UserService = userService;
            this.RoleService = roleService;
        }
        //
        // GET: /Authen/User/

        #region 属性

        public IUserService UserService { get; set; }


        public IRoleService RoleService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
            var model = new UserModel();
            return View(model);
        }

        [AdminPermission(PermissionCustomMode.Ignore)]
        public ActionResult List(DataTableParameter param)
        {
           var searchModel=new SearchModel();
           
            this.UpdateModel<SearchModel>(searchModel);
            
			string columns = Request["sColumns"];
			string sortCol = Request["iSortCol_0"];
			string sortDir = Request["sSortDir_0"];

			string [] sortColumns = columns.Split(',');

			//Sort Name & sort Direction
			string sortName = null;
			ListSortDirection sortDirection = ListSortDirection.Ascending;

			if (sortDir != "asc")
			{
				sortDirection = ListSortDirection.Descending;
			}

			switch (sortCol)
			{
				case "1": sortName = sortColumns[1]; break;
				case "2": sortName = sortColumns[2]; break;
				case "5": sortName = sortColumns[5]; break;
				case "6": sortName = sortColumns[6]; break;
				case "7": sortName = sortColumns[7]; break;
				default: sortName = sortColumns[6]; break;
			}
			
		 
           
            
			int total = UserService.Users.Count(t => t.IsDeleted == false);

			//构建查询表达式
			var expr = BuildSearchCriteria();


            var filterResult = this.UserService.Search(searchModel, sortName, sortDirection, param.iDisplayStart, param.iDisplayLength);
            
            int sortId = param.iDisplayStart + 1;

            var result = from c in filterResult
                         select new[]
                             {
                                 sortId++.ToString(), 
                                 c.LoginName,
                                 c.Email,
                                 c.FullName,                                
                                 c.Phone, 
                                 c.EnabledText,
                                 c.RegisterTime.ToString(), 
                                 c.LastLoginTime.ToString(), 
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
        private Expression<Func<User, Boolean>> BuildSearchCriteria()
        {
            DynamicLambdaHelper<User> bulider = new DynamicLambdaHelper<User>();
            Expression<Func<User, Boolean>> expr = null;
            if (!string.IsNullOrEmpty(Request["LoginName"]))
            {
                var data = Request["LoginName"].Trim();
                Expression<Func<User, Boolean>> tmp = t => t.LoginName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["FullName"]))
            {
                var data = Request["FullName"].Trim();
                Expression<Func<User, Boolean>> tmp = t => t.FullName.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Email"]))
            {
                var data = Request["Email"].Trim();
                Expression<Func<User, Boolean>> tmp = t => t.Email.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["Phone"]))
            {
                var data = Request["Phone"].Trim();
                Expression<Func<User, Boolean>> tmp = t => t.Phone.Contains(data);
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (Request["Enabled"] == "0" || Request["Enabled"] == "1")
            {
                var data = Request["Enabled"] == "1" ? true : false;
                Expression<Func<User, Boolean>> tmp = t => t.Enabled == data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["StartTime"]))
            {
                var data = Convert.ToDateTime(Request["StartTime"].Trim());
                Expression<Func<User, Boolean>> tmp = t => t.RegisterTime >= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            if (!string.IsNullOrEmpty(Request["EndTime"]))
            {
                var data = Convert.ToDateTime(Request["EndTime"].Trim()).AddDays(1);
                Expression<Func<User, Boolean>> tmp = t => t.RegisterTime <= data;
                expr = bulider.BuildQueryAnd(expr, tmp);
            }
            Expression<Func<User, Boolean>> tmpSolid = t => t.IsDeleted == false;
            expr = bulider.BuildQueryAnd(expr, tmpSolid);

            return expr;
        }

        #endregion

        [AdminPermission(PermissionCustomMode.Ignore)]
        public JsonResult CheckLoginName(string loginName)
        {
            bool isExist = false;
            var entity = UserService.Users.FirstOrDefault(t => t.LoginName.ToLower() == loginName.ToLower());
            if (entity != null)
            {
                isExist = true;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            //User Role
            model.RoleList = RoleService.GetKeyValueList();
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                this.CreateBaseData<UserModel>(model);
                OperationResult result = UserService.Insert(model);
                if (result.ResultType == OperationResultType.Success)
                {
                    return Json(result);
                }
                else
                {
                    //User Role
                    model.RoleList = RoleService.GetKeyValueList();
                    return PartialView(model);
                }
            }
            else
            {
                //User Role
                model.RoleList = RoleService.GetKeyValueList();
                return PartialView(model);
            }
        }

        public ActionResult Edit(int Id)
        {
            var model = new UpdateUserModel();
            var entity = UserService.Users.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new UpdateUserModel
                {
                    Id = entity.Id,
                    LoginName = entity.LoginName,
                    Email = entity.Email,
                    FullName = entity.FullName,
                    Phone = entity.Phone,
                    Enabled = entity.Enabled,
                    RegisterTime = entity.RegisterTime,
                    LastLoginTime = entity.LastLoginTime
                };
                //Selected Role 
                foreach (var userRole in entity.UserRole.Where(t => t.IsDeleted == false))
                {
                    model.SelectedRoleList.Add(userRole.RoleId);
                }

            }
            //User Role
            model.RoleList = RoleService.GetKeyValueList();
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult Edit(UpdateUserModel model)
        {
            if (ModelState.IsValid)
            {
                this.UpdateBaseData<UpdateUserModel>(model);
                OperationResult result = UserService.Update(model);
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

        public ActionResult ChangePwd(int Id)
        {
            var model = new ChangePwdModel();
            var entity = UserService.Users.FirstOrDefault(t => t.Id == Id);
            if (entity != null)
            {
                model.Id = entity.Id;
                model.LoginName = entity.LoginName;
                model.Email = entity.Email;
            }
            return PartialView(model);
        }

        [HttpPost]
        [AdminOperateLog]
        public ActionResult ChangePwd(ChangePwdModel model)
        {
            if (ModelState.IsValid)
            {
                this.UpdateBaseData<ChangePwdModel>(model);
                OperationResult result = UserService.Update(model);
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

        [AdminOperateLog]
        public ActionResult Delete(int Id)
        {
            var model = new UserModel
            {
                Id = Id
            };
            this.UpdateBaseData<UserModel>(model);
            OperationResult result = UserService.Delete(model);
            return Json(result);
        }
    }
}