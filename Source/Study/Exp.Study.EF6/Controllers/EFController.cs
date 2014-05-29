using Exp.Study.EF6.Data.Context;
using Exp.Study.EF6.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp.Study.EF6.Controllers
{
    public class EFController : Controller
    {
        IRepository<User> _user = null;
        IRepository<Address> _address = null;
        IDbContext _context = null;
        public EFController()
        {
            _context = new MyDbContext("ConnectionString");
            _user = new EfRepository<User>(_context);
            _address = new EfRepository<Address>(_context);
        }
        //
        // GET: /EF/
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult InitUser()
        {

            for (int loop = 0; loop < 2; loop++)
            {
                User u = new User()
                {
                    Name = loop.ToString(),

                };

                _user.Insert(u);
            }
            return View(_user.Table);
        }



    }
}