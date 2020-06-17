using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;
using EntityState = System.Data.Entity.EntityState;

namespace TestAppService.Controllers
{
    public class aController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();

        // GET: a
        public ActionResult Index()
        {
            var advertisment = db.Advertisment.Include(a => a.Location).Include(a => a.Status).Include(a => a.User);
            return View(advertisment.ToList());
        }

        // GET: a/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisment advertisment = db.Advertisment.Find(id);
            if (advertisment == null)
            {
                return HttpNotFound();
            }
            return View(advertisment);
        }

        // GET: a/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "City");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Title");
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName");
            return View();
        }

        // POST: a/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdvertismentID,Name,Description,AddDateTime,Budget,StatusID,LocationID,UserID")] Advertisment advertisment)
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

        // GET: a/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisment advertisment = db.Advertisment.Find(id);
            if (advertisment == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "City", advertisment.LocationID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Title", advertisment.StatusID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName", advertisment.UserID);
            return View(advertisment);
        }

        // POST: a/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdvertismentID,Name,Description,AddDateTime,Budget,StatusID,LocationID,UserID")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Location, "LocationID", "City", advertisment.LocationID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Title", advertisment.StatusID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "FirstName", advertisment.UserID);
            return View(advertisment);
        }

        // GET: a/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisment advertisment = db.Advertisment.Find(id);
            if (advertisment == null)
            {
                return HttpNotFound();
            }
            return View(advertisment);
        }

        // POST: a/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Advertisment advertisment = db.Advertisment.Find(id);
            db.Advertisment.Remove(advertisment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
