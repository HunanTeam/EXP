using Exp.Core.Data;

using ExpApp.Domain.Data.Repositories.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpApp.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _user;

        public HomeController(IUserRepository user )
        {
            _user = user;

        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
          
          return View();
        }

    }
}
