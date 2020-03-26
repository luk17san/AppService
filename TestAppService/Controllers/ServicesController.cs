using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;

namespace TestAppService.Controllers
{
    public class ServicesController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();

        public ActionResult ListServices()
        {
            var categories = db.Services;
            return View(categories.ToList());
        }
    }
}