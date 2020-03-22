using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;

namespace TestAppService.Controllers
{
    public class AdvertismentsController : Controller
    {
        private MyDatabaseEntities db = new MyDatabaseEntities();

        // GET: Advertisments
        public ActionResult Index()
        {
            return View(db.Advertisment.ToList());
        }

        // GET: Advertisments/Details/5
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

        // GET: Advertisments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Advertisments/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ad_ID,Ad_Name,Ad_Description,Ad_AddDataTime,Ad_Price,Ad_Services,Ad_Status,Ad_Location,Ad_Questions")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                db.Advertisment.Add(advertisment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(advertisment);
        }

        // GET: Advertisments/Edit/5
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
            return View(advertisment);
        }

        // POST: Advertisments/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ad_ID,Ad_Name,Ad_Description,Ad_AddDataTime,Ad_Price,Ad_Services,Ad_Status,Ad_Location,Ad_Questions")] Advertisment advertisment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(advertisment);
        }

        // GET: Advertisments/Delete/5
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

        // POST: Advertisments/Delete/5
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
