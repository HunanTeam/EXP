using ExpApp.Services.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpApp.Admin.Controllers
{
    public class TestController : Controller
    {
        public TestController(IUserService userService)
        {
            this.UserService = userService;
        }

        public IUserService UserService { get; set; }
        //
        // GET: /Test/

        public ActionResult Index()
        {
          
            return View();
        }

    }
}
