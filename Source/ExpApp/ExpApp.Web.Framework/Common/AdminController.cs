
using Exp.Tool.Helpers.ToolsHelper;
using ExpApp.Domain.Models.Sys;
using ExpApp.Site.Common.Models;
using ExpApp.Web.Framework.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ExpApp.Web.Framework.Common
{
	[AdminPermission(PermissionCustomMode.Enforce)]
    public class AdminBaseController : Controller
    {
		public AdminBaseController()
		{
			//TODO: Test
            //var userRole = new List<UserRole> { new UserRole { Id = 1, UserId = 1, RoleId = 1 } };
            //var user = new User { Id = 1, LoginName = "admin", LoginPwd = "8wdJLK8mokI=", UserRole = userRole };
            //SessionHelper.SetSession("CurrentUser", user);
		}

		protected User GetCurrentUser()
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			return user;
		}

		protected void CreateBaseData<T>(T model) where T : EntityCommon
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (user != null)
			{
				model.CreateId = user.Id;
				model.CreateBy = user.LoginName;
				model.CreateTime = DateTime.Now;
				model.ModifyId = user.Id;
				model.ModifyBy = user.LoginName;
				model.ModifyTime = DateTime.Now;
			}
		}

		protected void UpdateBaseData<T>(T model) where T : EntityCommon
		{
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (user != null)
			{
				model.ModifyId = user.Id;
				model.ModifyBy = user.LoginName;
				model.ModifyTime = DateTime.Now;
			}
		}
	}
}