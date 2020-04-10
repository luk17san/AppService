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
        public ActionResult Ad_List()
        {
            var ad_list = db.Advertisment;
            return View(ad_list.ToList());
        }

        public ActionResult ListQuestions()
        {
            AdContext adContext = new AdContext();
            List<Questions> questions = adContext.Questions.ToList();
            return View(questions);
        }
        public PartialViewResult ListAnswers(int a_id)
        {
            AdContext adContext = new AdContext();
            List<Q_Answers> answer = adContext.Q_Answers
               .Where(a => a.A_Question_ID == a_id).ToList();

            return PartialView(answer);
        }
        public ActionResult ListQ() //int? aq_id)
        {
            Model_QA model_QA = new Model_QA();
            model_QA.Questions = db.Questions;
            model_QA.Q_Answers = db.Q_Answers;
                //ViewBag.A_Question_ID = aq_id;
                //model_QA.Q_Answers = model_QA.Q_Answers.Where(
                 //   i => i.A_Question_ID == aq_id).ToList();
            
                return View(model_QA);
        }
       }
}
        /*
        public ActionResult QuestionsList()
        {
            ViewModel_Ad model_ad = new ViewModel_Ad();
            model_ad.Questions = db.Questions;
            model_ad.Q_Answers = db.Q_Answers;

            if (Q_id != null)
            {
                ViewBag.Question_ID = Q_id.Value;
                model_ad.Q_Answers = model_ad.Questions.Where(
                    i => i.Question_ID == Q_id.Value).Single().Q_Answers;
            }
            if (A_id != null)
            {
                ViewBag.A_ID = A_id.Value;
                model_ad.Q_Answers = model_ad.Q_Answers.Where(
                    i => i.A_ID == A_id.Value);
            }
            return View(model_ad);
        
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
            var q_answers= db.Q_Answers;

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
    }
}
*/