using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp.Study.Mvc.Views
{
    public class TestController : Controller
    {
        #region Nav
        public ActionResult Index()
        {

            return View();

        }
        #endregion
        /// <summary>
        /// JS替换占位符（同时加载JS）
        /// </summary>
        /// <returns></returns>
        public ActionResult ReplaceHolder()
        {
            return View();
        }
        
        public ActionResult PlaceHolderContent()
        {
            return PartialView();
        }
    }
}
