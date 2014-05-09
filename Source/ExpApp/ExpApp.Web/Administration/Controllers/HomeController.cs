
using ExpApp.Site.Common.Models;
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
    public class HomeController : AdminController
    {
        //
        // GET: /Common/Home/

		[AdminLayout]
        public ActionResult Index()
        {
            return View();
        }
	}
}