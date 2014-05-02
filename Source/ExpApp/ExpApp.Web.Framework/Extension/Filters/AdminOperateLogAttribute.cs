
using Exp.Tool.Helpers.ToolsHelper;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services.Sys;
using ExpApp.Site.Models.SysConfig.OperateLog;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace  ExpApp.Web.Framework.Extension.Filters
{
	/// <summary>
	/// 记录动作Log
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AdminOperateLogAttribute : ActionFilterAttribute 
    {
        public IPermissionService PermissionService { get; set; }
		public IOperateLogService OperateLogService { get; set; }

		public AdminOperateLogAttribute()
		{
			var container = HttpContext.Current.Application["Container"] as CompositionContainer;
			PermissionService = container.GetExportedValueOrDefault<IPermissionService>();
			OperateLogService = container.GetExportedValueOrDefault<IOperateLogService>();
		}


		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (user != null)
			{
				var area = filterContext.RouteData.DataTokens["area"] != null ? filterContext.RouteData.DataTokens["area"].ToString() : "";
				var controller = filterContext.RouteData.Values["controller"].ToString();
				var action = filterContext.RouteData.Values["action"].ToString();
				var actionName = action.ToLower();
				var permission = PermissionService.Permissions.FirstOrDefault(t => t.Code.ToLower() == actionName && t.Enabled == true && t.IsDeleted == false);
				var description = string.Empty;
				if(permission != null)
				{
					description = permission.Name;
				}

				var model = new OperateLogModel { 
					Area = area,
					Controller = controller,
					Action = action,
					Description = description,
					LogTime = DateTime.Now,
					UserId = user.Id,
					LoginName = user.LoginName,
					IPAddress = Tools.GetUserIp()
				};

				OperateLogService.Insert(model);
			}
		}
    }
}