using Exp.Study.Mvc.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp.Study.Mvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MyClass c)
        {
            
            var idsTmp = c.Name;
            if (idsTmp != null)
            {
                return Json(new { success = true, len = idsTmp.Length });
            }
            return Json(new { success = false });
        }


    }
}
