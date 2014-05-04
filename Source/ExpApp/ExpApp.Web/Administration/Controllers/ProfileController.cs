using Exp.Core;
using Exp.Tool.Helpers.SecurityHelper;
using Exp.Tool.Helpers.ToolsHelper;
using ExpApp.Domain.Models.Sys;
using ExpApp.Services.Sys;
using ExpApp.Site.Common.Models;
using ExpApp.Site.Models.AdminCommon;
using ExpApp.Site.Models.Authen.User;
using ExpApp.Web.Framework.Common;
using ExpApp.Web.Framework.Extension.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ExpApp.Admin.Controllers
{	
	 
	
    [AdminPermission(PermissionCustomMode.Ignore)]
	public class ProfileController : AdminBaseController
    {
        public ProfileController(IUserService userService)
        {
            this.UserService = userService;
        }
        //
        // GET: /Common/Profile/
        #region 属性
      
		public IUserService UserService { get; set; }
        #endregion

        [AdminLayout]
        public ActionResult Index()
        {
			var entity = this.GetCurrentUser();
			var model = new ProfileModel { 
				Id = entity.Id,
				LoginName = entity.LoginName,
				Email = entity.Email,
				FullName = entity.FullName,
				Phone = entity.Phone,
				LoginCount = entity.LoginCount,
				LastLoginTime = entity.LastLoginTime,
				RegisterTime = entity.RegisterTime
			};
			return View(model);
        }

		[AdminLayout]
		public ActionResult ChangePwd()
		{
			var entity = this.GetCurrentUser();
			var model = new ChangePwdModel { 
				Id = entity.Id,
				LoginName = entity.LoginName,
				Email = entity.Email
			};
			return View(model);
		}

		[HttpPost]
		public ActionResult ChangePwd(ChangePwdModel model)
		{
			if (ModelState.IsValid)
			{
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

		public ActionResult CheckPwd(string oldLoginPwd)
		{
			bool result = true;
			var user = SessionHelper.GetSession("CurrentUser") as User;
			if (DESProvider.DecryptString(user.LoginPwd) != oldLoginPwd)
			{
				result = false;
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}
	}
}