using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using TestAppService.Models;

namespace TestAppService.Controllers
{
    public class UserController : Controller
    {
        // Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {
            bool Status = false;
            string message = "";
            //Model Validation
            if (ModelState.IsValid)
            {
                #region //Email is already Exist
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion
                #region //Generate Activation Code
                user.ActivationCode = Guid.NewGuid();
                #endregion
                #region // Password Hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion
                user.IsEmailVerified = false;

                #region // Save to Database
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    dc.User.Add(user);
                    dc.SaveChanges();

                    //Send Email to User

                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registrarion successfully done. Account activation link" +
                        "has been sent to your email id:" + user.EmailID;
                    Status = true;
                    #endregion
                }
            }
            else
            {
                message = "Invalid Request";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
        //Verify Email

        //Verify Email LINK

        //Login

        //Login POST

        //Logout

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.User.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            /* var scheme = Request.Url.Scheme;
             var host = Request.Url.Host;
             var port = Request.Url.Port;

             string url = scheme +"://"+host+
             */
            var verifyUrl = "/User/VerifyAccount" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("TestASP.NETService@gmail.com", "Luk Test");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "Test123service"; //Replace wit actual password
            string subject = "Your accont is successfully created!";

            string body = "<br/><br/> We are exited to tell you that your account is" +
                " successfully created. Please click on below link to verify your acount" +
                "<br/><br/><a href='" + link + "'>" + link + "</a>";

            var smpt = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smpt.Send(message);
        }
    }
}