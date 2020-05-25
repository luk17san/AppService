using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using TestAppService.Models;
using System.Web.Security;
using System.Web;
using System.Data.Entity;

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
                var isExist = IsEmailExist(user.Email);
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
                using (DBServiceEntities dc = new DBServiceEntities())
                {
                    dc.User.Add(user);
                    dc.SaveChanges();

                    //Send Email to User

                    SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
                    message = "Registrarion successfully done. Account activation link" +
                        "has been sent to your email id:" + user.Email;
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
        //Verify Account

        [HttpGet]
        public ActionResult VerifyAccount(string id)
    {
        bool Status = false;
        using (DBServiceEntities dc = new DBServiceEntities())
        {
            dc.Configuration.ValidateOnSaveEnabled = false; // This line I have added hewe to avoid
                                                            // Confirm password does not mach issue on save changes 
            var v = dc.User.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
            if (v != null)
            {
                v.IsEmailVerified = true;
                dc.SaveChanges();
                Status = true;
            }
            else
            {
                ViewBag.Message = "Invlid Request";
            }
            ViewBag.Status = Status;
            return View();
        }
    }

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl)
        {
            string message = "";
            using (DBServiceEntities dc = new DBServiceEntities())
            {
                var v = dc.User.Where(a => a.Email == login.Email).FirstOrDefault();
                if(v !=null)
                {
                    if (string.Compare(Crypto.Hash(login.Password),v.Password)==0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; //525600min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.Email, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        Session["UserId"] = dc.User.Single(x => x.Email == login.Email).User_ID;
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("MyProfile", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
            }

                ViewBag.Message = message;
            return View();
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserId"] = 0;

            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (DBServiceEntities dc = new DBServiceEntities())
            {
                var v = dc.User.Where(a => a.Email == emailID).FirstOrDefault();
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
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
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