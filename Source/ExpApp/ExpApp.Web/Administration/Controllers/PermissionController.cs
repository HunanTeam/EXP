using Exp.Core;
using Exp.Tool.Helpers;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services.Sys;
using ExpApp.Site.Common.Models;
using ExpApp.Site.Models.Authen.Permission;
using ExpApp.Web.Framework.Common;
using ExpApp.Web.Framework.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

 

namespace ExpApp.Admin.Controllers
{
	 
    public class PermissionController : AdminBaseController
    {
        //
		// GET: /Authen/Permission/
        public PermissionController(IPermissionService permissionService)
        {
            this.PermissionService = permissionService;
        }
		#region 属性
		 
		public IPermissionService PermissionService { get; set; }
		#endregion

		[AdminLayout]
        public ActionResult Index()
        {
			var model = new PermissionModel();
            return View(model);
        }

		[AdminPermission(PermissionCustomMode.Ignore)]
		public ActionResult List(DataTableParameter param)
		{
			int total = PermissionService.Permissions.Count(t => t.IsDeleted == false);

			//构建查询表达式
			var expr = BuildSearchCriteria();

			var filterResult = PermissionService.Permissions.Where(expr).Select(t => new PermissionModel
			{
				Id = t.Id,
				Name = t.Name,
				Code = t.Code,			
				Icon = t.Icon,
				OrderSort = t.OrderSort,
				Description = t.Description,
				Enabled = t.Enabled
			}).OrderBy(t => t.OrderSort).Skip(param.iDisplayStart).Take(param.iDisplayLength).ToList();

			int sortId = param.iDisplayStart + 1;

			var result = from c in filterResult
						 select new[]
                             {
                                 sortId++.ToString(), 
								 c.Name,
                                 c.Code,								                                                
                                 c.Icon, 
                                 c.OrderSort.ToString(),
								 c.Description,
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
		private Expression<Func<Permission, Boolean>> BuildSearchCriteria()
		{
            DynamicLambdaHelper< Permission> bulider = new DynamicLambdaHelper<Permission>();
			Expression<Func< Permission, Boolean>> expr = null;
			if (!string.IsNullOrEmpty(Request["Name"]))
			{
				var data = Request["Name"].Trim();
				Expression<Func<Permission, Boolean>> tmp = t => t.Name.Contains(data);
				expr = bulider.BuildQueryAnd(expr, tmp);
			}

			Expression<Func<ExpApp.Domain.Models.Sys.Permission, Boolean>> tmpSolid = t => t.IsDeleted == false;
			expr = bulider.BuildQueryAnd(expr, tmpSolid);

			return expr;
		}

		#endregion

        public ActionResult Create()
        {
            var model = new PermissionModel();
            return PartialView(model);
        }

        [HttpPost]
		[AdminOperateLog]
        public ActionResult Create(PermissionModel model)
        {
            if (ModelState.IsValid)
            {
                OperationResult result = PermissionService.Insert(model);
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
            var model = new PermissionModel();
            var entity = PermissionService.Permissions.FirstOrDefault(t => t.Id == Id);
            if (null != entity)
            {
                model = new PermissionModel
                {
                    Id = entity.Id,
                    Code = entity.Code,
                    Icon = entity.Icon,
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
        public ActionResult Edit(PermissionModel model)
        {
            if (ModelState.IsValid)
            {
                OperationResult result = PermissionService.Update(model);
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
            OperationResult result = PermissionService.Delete(Id);
            return Json(result);
        }
	}
}