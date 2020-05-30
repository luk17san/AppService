using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;


namespace TestAppService.Controllers
{
    public class ListServicesController : Controller
    {
        // GET: ListAd
        public ActionResult ListCategories()
        {
            ServicesContext adContext = new ServicesContext();
            List<Categories> categories = adContext.Categories.ToList();
            return View(categories);
        }

       public ActionResult ListServices(int category_id)
        {
            ServicesContext adContext = new ServicesContext();
            List<Services> services = adContext.Services
               .Where(s => s.Service_Category_ID == category_id).ToList();

            return View(services
                );
        }
        public ActionResult DetailsServices(int id)
        {
            ServicesContext adContext = new ServicesContext();
            Services service = adContext.Services.Single(ds => ds.Service_ID == id);

            return View(service);
        }
    }
}