using Exp.Core.Data;
using Exp.Core.Domain.Common;
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
        private readonly IRepository<Menu, int> _userRepository;

        public HomeController(IRepository<Menu, int> userRepository)
        {
            _userRepository = userRepository;

        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //_userRepository.AutoCommit = false;
            //for (int loop = 0; loop < 10; loop++)
            //{
            //    var user = new User { Email = loop.ToString(), Name = loop.ToString(), CreateOn = DateTime.Now, IsDeleted = true };
            //    user.UserRoles.Add(new Core.Domain.Securities.Role { Name = loop.ToString(), IsEnabled = true, Description = DateTime.Now.ToString() });
            //    _userRepository.Insert(user);
            //}
            //var result = _userRepository.UnitOfWork.Commit();
            //var uses = _userRepository.Entities.FirstOrDefault();
            Menu m = new Menu() { Title="父亲"};
            m.ChildMenus = new List<Menu>();
            m.ChildMenus.Add(new Menu() { Title="儿子"});
            var r= _userRepository.Insert(m);
            _userRepository.UnitOfWork.Commit();
          return View(r);
        }

    }
}
