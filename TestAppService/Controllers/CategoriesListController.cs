using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common.EntitySql;
using System.Data.Entity;
using TestAppService.Models;

namespace TestAppService.Controllers
{
    public class CategoriesListController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();

        // GET: Categories
        public ActionResult Index_Categories()
        {
            var categories = db.Categories.Include(c => c.Services);
            return View(categories.ToList());
        }
        

    }
}