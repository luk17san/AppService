using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;
using TestAppService.Models.ViewModel;


namespace TestAppService.Controllers
{
    public class ServicesController : Controller
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
               .Where(s => s.CategoryID == category_id).ToList();

            return View(services);
        }
        public ActionResult DetailsServices(int id)
        {
            ServicesContext adContext = new ServicesContext();
            Services service = adContext.Services.Single(ds => ds.ServiceID == id);

            return View(service);
        }
        public ActionResult FiltrServices()
        {
            return View();
        }
        public ActionResult SearchServices()
        {
            return View();
        }
    }
}