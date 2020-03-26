using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;
using TestAppService.Models.Extended;

namespace TestAppService.Controllers
{
    public class AdvertismentController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();

        public ActionResult Index_Ad()
        {
            List<ExQuestions> qlist = new List<ExQuestions>();
            var q = db.Questions;
            return View(Questions.ToList());
            

          
            //qlist.Add(new ExQuestions { Question_ID = 1, Q_Name = "AAAA", IsAvailable = true });

            //ViewBag.qlist = qlist;
            //return View();
        }

    }

}
