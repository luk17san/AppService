using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;
namespace TestAppService.Controllers
{
    
    public class TradesmanController : Controller
    {
        private readonly DBServiceEntities db = new DBServiceEntities();
        // GET: Tradesman
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTradesman()
        {
            var tradesman = db.User.ToList().Where(p => p.RoleID == 2);
            return View(tradesman);
        }


        public ActionResult FiltrTradsman()
        {
            return View();
        }
        public ActionResult SearchTradesman()
        {
            return View();
        }
    }
}