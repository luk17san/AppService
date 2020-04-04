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
            return View();
        }
       
        public ActionResult QuestionsList()
        {
            var questions = db.Questions;
            return View(questions.ToList());
        }
        public ActionResult Questions()
        {
            QuestionModel qmodel = new QuestionModel();
            using(DBServiceEntities db = new DBServiceEntities())
            {
                qmodel.Questions = db.Questions.ToList();
            }
            return View(qmodel);
        }

        public ActionResult Answers_List()
        {
            var q_answers = db.Q_Answers;
            return View(q_answers.ToList());
        }

        public ActionResult Answers()
        {
            AnswersModel anmodel = new AnswersModel();
            using (DBServiceEntities db = new DBServiceEntities())
            {
               
                anmodel.Q_Answers = db.Q_Answers.ToList();
           
            }
            return View(anmodel);
        }
        public ActionResult Ad_List()
        {
            var ad_list = db.Advertisment;
            return View(ad_list.ToList());
        }
    }

}
