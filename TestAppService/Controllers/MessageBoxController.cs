using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestAppService.Controllers
{
    public class MessageBoxController : Controller
    {
        // GET: MessageBox
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListMessage()
        {
            return View();
        }

        public ActionResult ReadMessage()
        {
            return View();
        }

        public ActionResult AnswerMessage()
        {
            return View();
        }
        public ActionResult DeleteMessage()
        {
            return View();
        }
    }
}