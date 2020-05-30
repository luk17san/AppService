using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using TestAppService.Models;
using TestAppService.Models.Extended;

namespace TestAppService.Controllers
{
    public class UserProfileController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            if (userid == 0)
            {
                return RedirectToAction("Login", "User");
            }
            return View(db.User.Find(userid));
        }

        public ActionResult UserAdvertisment()
        {

            int userid = Convert.ToInt32(Session["UserId"]);
            if (userid == 0)
            {
                return RedirectToAction("Login", "User");
            }
            AdContext adContext = new AdContext();
            List<Advertisment> ad = adContext.Advertisments
                .Where(s => s.Ad_User_ID == userid).ToList();

            return View(ad);
        }
        public ActionResult UserProfesion()
        {
            ServicesContext adContext = new ServicesContext();
            List<Services> services = adContext.Services.ToList();

            return View(services);

        }
        [HttpPost, ActionName("UserProfesion")]
        public ActionResult UserProfesion(IEnumerable<Services>itemservice,FormCollection id)
        {
            int serviceid = Convert.ToInt32(id["id"]);
            int userid = Convert.ToInt32(Session["UserId"]);
            ServicesContext adContext = new ServicesContext();
            List<Services> services = adContext.Services.ToList();
            if (services.Count() == 0)
            {
                ViewBag.Message = "Please select Service";
                return View(services);
            }
            else
            {
                /*foreach(Services s in itemservice)
                {
                    if(s.IsChecked)
                    {
                        var save = new User_Profesion
                        {
                            Id_Profesion = serviceid,
                            Id_User = userid
                        };
                        db.User_Profesion.Add(save);
                        db.SaveChanges();
                    }
                }*/
                ViewBag.Message = "Service is add to ";
            }

            return View();
        }
    }   
}
