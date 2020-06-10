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

            List<Advertisment> ad = db.Advertisment
                .Where(s => s.Ad_User_ID == userid).ToList();

            return View(ad);
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
                             s.Service_ID,
                             s.Service_Name,
                             IsChecked = ((from up in db.User_Profesion
                                         where (up.Id_Profesion == id) & (up.Id_Service == s.Service_ID)
                                         select up).Count() > 0)
                         };

            var MyViewModel = new UserViewModel();

            MyViewModel.User_ID = id.Value;
            MyViewModel.First_Name = user.First_Name;
            MyViewModel.Last_Name = user.Last_Name;


            var MyCheckBoxList = new List<CheckBoxViewModelProfesion>();
            foreach (var item in Result)
            {
                MyCheckBoxList.Add(new CheckBoxViewModelProfesion
                {
                    Id = item.Service_ID,
                    Name = item.Service_Name,
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

                foreach (var item in db.User_Profesion)
                {
                    if (item.Id_User == userid)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }
                foreach(var item in user.UserVM)
                {
                    if(item.IsChecked)
                    {
                        db.User_Profesion.Add(new User_Profesion() {  Id_User = userid, Id_Service=item.Id });
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }


    }
}
