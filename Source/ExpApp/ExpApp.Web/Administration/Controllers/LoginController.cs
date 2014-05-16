using Exp.Core;
using Exp.Tool.Helpers.SecurityHelper;
using ExpApp.Services.Sys;
using ExpApp.Site.Models.Authen.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ExpApp.Admin.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(IUserService userService)
        {
            this.UserService = userService;
        }

        #region 属性

        public IUserService UserService { get; set; }
        #endregion

        public ActionResult Index()
        {
            //TODO:TEST

            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckLogin(LoginModel model)
        {
            var result= this.UserService.CheckLogin(model);
            if (result.ResultType==OperationResultType.Success)
            {
                Session["CurrentUser"] = result.Result;
                Session.Timeout = 20;
            }

            return Json(result);
        }

        public ActionResult SignOut()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ForgetPwd()
        {
            return PartialView();
        }
    }
}