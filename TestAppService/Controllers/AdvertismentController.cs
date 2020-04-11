using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppService.Models;



namespace TestAppService.Controllers
{
    public class AdvertismentController : Controller
    {
        private DBServiceEntities db = new DBServiceEntities();
        public ActionResult Create_Ad()
        {
            Model_QA model_QA = new Model_QA();
            model_QA.Questions = db.Questions;
            model_QA.Q_Answers = db.Q_Answers;

            return View(model_QA);
        }
        [HttpPost]
        public ActionResult Create_Ad(Model_QA model)
        {
            var selectedAnswers = model.Q_Answers.
                Where(x => x.IsChecked == true).ToList<Q_Answers>();
            return Content(String.Join(",", selectedAnswers.Select(x => x.A_Name)));
        }
        
        public ActionResult Ad_List()
        {
            var ad_list = db.Advertisment;
            return View(ad_list.ToList());
        }

        public ActionResult ListQ()
        {
            Model_QA model_QA = new Model_QA();
            model_QA.Questions = db.Questions;
            model_QA.Q_Answers = db.Q_Answers;

                return View(model_QA);
        }
       }
}
      