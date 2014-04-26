using Exp.Core.Data;
using Exp.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User, int> _userRepository;
        public HomeController(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
