using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;

namespace TestAppService.Controllers
{
    public class Home2Controller : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel
            {
                AvailableFruits = GetFruits()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            if (ModelState.IsValid)
            {
                var fruits = string.Join(",", model.SelectedFruits);

                // Save data to database, and redirect to Success page.

                return Content("Success");
            }
            model.AvailableFruits = GetFruits();
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        private IList<SelectListItem> GetFruits()
        {
            return new List<SelectListItem>
        {
            new SelectListItem {Text = "Apple", Value = "Apple"},
            new SelectListItem {Text = "Pear", Value = "Pear"},
            new SelectListItem {Text = "Banana", Value = "Banana"},
            new SelectListItem {Text = "Orange", Value = "Orange"},
        };
        }
    }
}