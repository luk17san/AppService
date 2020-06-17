using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using TestAppService.Models;
using TestAppService.Models.Extended;
using System.Data.Entity.Infrastructure;
using System.Web.Services.Description;
using System.Net;
using System.Net.Http;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;

using System.Data;
using EntityState = System.Data.Entity.EntityState;

namespace TestAppService.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly DBServiceEntities db = new DBServiceEntities();

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

        public ActionResult DeleteProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: u/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailsProfesion()
        {

            ProfesionViewModel model = new ProfesionViewModel();
            model.UserProfesions = db.UserProfesion.ToList();
            return View(model);
        }
       
        public ActionResult UserProfesion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
           
            var Result = from s in db.Services
                         select new
                         {
                             s.ServiceID,
                             s.Name,
                             IsChecked = ((from up in db.UserProfesion
                                         where (up.ProfesionID == id) & (up.ServiceID == s.ServiceID)
                                         select up).Count() > 0)
                         };

            var MyViewModel = new UserViewModel();

            MyViewModel.UserID = id.Value;
            MyViewModel.FirstName = user.FirstName;
            MyViewModel.LastName = user.LastName;


            var MyCheckBoxList = new List<CheckBoxViewModelProfesion>();
            foreach (var item in Result)
            {
                MyCheckBoxList.Add(new CheckBoxViewModelProfesion
                {
                    Id = item.ServiceID,
                    Name = item.Name,
                    IsChecked = item.IsChecked
                });
            }
            MyViewModel.UserVM = MyCheckBoxList;
            return View(MyViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserProfesion(UserViewModel user)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            if (ModelState.IsValid)
            {
                //var MyProfesion = db.User.Find(user.User_ID);

                //MyProfesion.First_Name = user.First_Name;
                //MyProfesion.Last_Name = user.Last_Name;

                foreach (var item in db.UserProfesion)
                {
                    if (item.UserID == userid)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach(var item in user.UserVM)
                {
                    if(item.IsChecked)
                    {
                        db.UserProfesion.Add(new UserProfesion() {  UserID = userid, ServiceID=item.Id });
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }
        public ActionResult UserListAdvertisment()
        {

            int userid = Convert.ToInt32(Session["UserId"]);
            if (userid == 0)
            {
                return RedirectToAction("Login", "User");
            }

            List<Advertisment> ad = db.Advertisment
                .Where(s => s.UserID == userid).ToList();

            return View(ad);
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "Name", user.RoleID);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "UserID,FirstName,LastName,Email,DateOfBirth,Phone,Password,IsEmailVerified,ActivationCode,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Role, "RoleID", "Name", user.RoleID);
            return View(user);
        }
    }
}
