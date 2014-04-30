﻿using ExpApp.Side.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpApp.Domain.Models.System;

namespace ExpApp.Admin.Common
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        protected User GetCurrentUser()
        {
            return null;
            //var user = SessionHelper.GetSession("CurrentUser") as User;
            //return user;
        }

        protected void CreateBaseData<T>(T model) where T : EntityCommon
        {
            var user = GetCurrentUser();
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
            var user = GetCurrentUser();
            if (user != null)
            {
                model.ModifyId = user.Id;
                model.ModifyBy = user.LoginName;
                model.ModifyTime = DateTime.Now;
            }
        }
    }
}