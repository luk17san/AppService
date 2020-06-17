using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;



namespace TestAppService.Controllers
{
    public class AdvertismentController : Controller
    {
        private readonly DBServiceEntities db = new DBServiceEntities();

        
        public ActionResult CreateAdvertisment()
        {
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "City");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Title");
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdvertisment([Bind(Include = "AdvertismentID,Name,Description,AddDateTime,Budget,StatusID,LocationID,UserID")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                db.Advertisment.Add(advertisment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "City", advertisment.LocationID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Title", advertisment.StatusID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName", advertisment.UserID);
            
            return View(advertisment);
        }

        public ActionResult EditAdvertisment()
        {
            return View();
        }

        public ActionResult DeleteAdvertisment()
        {
            return View();
        }
        public ActionResult StatusAdvertisment()
        {
            return View();
        }
        public ActionResult ListAdvertisment()
        {
            var ad_list = db.Advertisment;
            return View(ad_list.ToList());
        }
        /*
        public ActionResult ListQ()
        {
            ServiceDbContext model_QA = new ServiceDbContext();
            model_QA.Questions = db.Questions;
            model_QA.Answers = db.Answers;

                return View(model_QA);
        }*/
    }
}
      