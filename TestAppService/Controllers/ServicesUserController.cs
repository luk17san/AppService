using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;
using TestAppService.Models.Extended;
using EntityState = System.Data.Entity.EntityState;

namespace TestAppService.Controllers
{
    public class ServicesUserController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();

        // GET: ServicesUser
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Ad_Services).Include(s => s.Categories).Include(s => s.Price_Measurment).Include(s => s.User_Profesion);
            return View(services.ToList());
        }

        // GET: ServicesUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // GET: ServicesUser/Create
        public ActionResult Create()
        {
            ViewBag.Service_ID = new SelectList(db.Ad_Services, "AdS_ID", "AdS_ID");
            ViewBag.Service_Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name");
            ViewBag.Service_PMeasurment_ID = new SelectList(db.Price_Measurment, "PM_ID", "PM_Name");
            ViewBag.Service_ID = new SelectList(db.User_Profesion, "Id_Profesion", "Id_Profesion");
            return View();
        }

        // POST: ServicesUser/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Service_ID,Service_Name,Service_Category_ID,Service_Price,Service_PMeasurment_ID")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Service_ID = new SelectList(db.Ad_Services, "AdS_ID", "AdS_ID", services.Service_ID);
            ViewBag.Service_Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name", services.Service_Category_ID);
            ViewBag.Service_PMeasurment_ID = new SelectList(db.Price_Measurment, "PM_ID", "PM_Name", services.Service_PMeasurment_ID);
            ViewBag.Service_ID = new SelectList(db.User_Profesion, "Id_Profesion", "Id_Profesion", services.Service_ID);
            return View(services);
        }

        // GET: ServicesUser/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Service_ID = new SelectList(db.Ad_Services, "AdS_ID", "AdS_ID", services.Service_ID);
            //ViewBag.Service_Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name", services.Service_Category_ID);
            //ViewBag.Service_PMeasurment_ID = new SelectList(db.Price_Measurment, "PM_ID", "PM_Name", services.Service_PMeasurment_ID);
           //ViewBag.Service_ID = new SelectList(db.User_Profesion, "Id_Profesion", "Id_Profesion", services.Service_ID);

            var Result = from s in db.Services
                         select new
                         {
                             s.Service_ID,
                             s.Service_Name,
                             Checked = ((from up in db.User_Profesion
                                         where (up.Id_Profesion == id) & (up.Id_Service == s.Service_ID)
                                         select up).Count() > 0)
                         };

            var MyViewModel = new UserViewModel();

            MyViewModel.Id_ServiceUser = id.Value;
            MyViewModel.Name = services.Service_Name;

            var MyCheckBoxList = new List<CheckBoxViewModelProfesion>();
            foreach (var item in Result)
            {
                MyCheckBoxList.Add(new CheckBoxViewModelProfesion
                {
                    Id = item.Service_ID,
                    Name = item.Service_Name,
                    IsChecked = item.Checked
                });
            }
            MyViewModel.ServiceUserVM = MyCheckBoxList;
            return View(MyViewModel);
        }

        // POST: ServicesUser/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Service_ID,Service_Name,Service_Category_ID,Service_Price,Service_PMeasurment_ID")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Service_ID = new SelectList(db.Ad_Services, "AdS_ID", "AdS_ID", services.Service_ID);
            //ViewBag.Service_Category_ID = new SelectList(db.Categories, "Category_ID", "Category_Name", services.Service_Category_ID);
            //ViewBag.Service_PMeasurment_ID = new SelectList(db.Price_Measurment, "PM_ID", "PM_Name", services.Service_PMeasurment_ID);
            //ViewBag.Service_ID = new SelectList(db.User_Profesion, "Id_Profesion", "Id_Profesion", services.Service_ID);
            return View(services);
        }

        // GET: ServicesUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: ServicesUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Services services = db.Services.Find(id);
            db.Services.Remove(services);
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
        }   */
    }
}
        