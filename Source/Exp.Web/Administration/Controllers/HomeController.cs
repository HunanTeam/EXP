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
            for (int loop = 0; loop < 10; loop++)
            {
                //_userRepository.Insert(new User { Email = loop.ToString(), Name = loop.ToString(), CreateOn = DateTime.Now, IsDeleted = true }, false);
            }
            var result = _userRepository.UnitOfWork.Commit();
            return View(result);
        }

    }
}
