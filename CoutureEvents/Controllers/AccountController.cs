using CoutureEvents.Models;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CoutureEvents.Controllers
{
    public class AccountController : Controller
    {
        //Get Account
        [Authorize]
        public ActionResult Index()
        {
            AccountDetailsModel model = new AccountDetailsModel();
            return View(model);
        }

        // GET: Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            return View(model);
        }

        //POST Account/Register
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(CustomerModel model)
        {
            if(ModelState.IsValid)
            {
                if(WebMatrix.WebData.WebSecurity.UserExists(model.Email))
                {
                    ModelState.AddModelError("Email", "Could not create a user with this email address");
                }
                else
                {
                    string token = WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password,
                    new
                    {
                        ID = model.ID,
                        BrideFirstName = model.BrideFirstName,
                        BrideLastName =model.BrideFirstName,
                        GroomFirstName = model.GroomFirstName,
                        GroomLastName = model.GroomFirstName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Address = model.Address,
                        City = model.City,
                        WeddingDate = model.WeddingDate,
                        NumberOfGuests = model.NumberOfGuests,
                        NumberOfGroomsmen = model.NumberOfGroomsmen,
                        NumberOfBridesmaids = model.NumberOfBridesmaids,
                        Password = model.Password

                    }, true);

                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
                    SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

                    SendGrid.Helpers.Mail.Email from = new SendGrid.Helpers.Mail.Email("claytonhalaska@gmail.com");
                    string subject = "Couture Events Account Verification";
                    SendGrid.Helpers.Mail.Email to = new SendGrid.Helpers.Mail.Email(model.Email);
                    Content content = new Content("text/html", "emailContent");

                    string emailContent = string.Format("<html><head><body><a href=\"{0}\"Complete your registration </body></head></html>", Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/RegistrationComplete/" + HttpUtility.UrlEncode(token) + "?email=" + model.Email);
                    Mail mail = new Mail(from, subject, to, content);

                    client.client.mail.send.post(requestBody: mail.Get());
                 





                    return RedirectToAction("RegistrationComplete");
                }
                
            }
            return View(model);
           
        }
        public ActionResult ForgotPassword()
        {
            ForgotPasswordModel model = new ForgotPasswordModel();
            return View(model);
        }

        //POST Account/ForgotPassword
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            string email = model.EmailAddress;
            string resetToken = WebMatrix.WebData.WebSecurity.GeneratePasswordResetToken(model.EmailAddress);
            string resetUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Account/CompleteForgotPassword?resetToken" + resetToken;


            string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
            SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

            SendGrid.Helpers.Mail.Email from = new SendGrid.Helpers.Mail.Email("Suzanne@coutureEventsChicago.com");
            string subject = "Couture Events: Password Reset!";
            SendGrid.Helpers.Mail.Email to = new SendGrid.Helpers.Mail.Email(model.EmailAddress);

            Content content = new Content("text/html", " ");
            Mail mail = new Mail(from, subject, to, content);

            mail.TemplateId = "be1b809e-4cc5-425c-8b7e-cc9846b0777f";
            mail.Personalization[0].AddSubstitution("-token-", resetToken);
            mail.Personalization[0].AddSubstitution("-url-", resetUrl);

            client.client.mail.send.post(requestBody: mail.Get());
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CompleteForgotPassword(string resetToken)
        {
            CompleteForgotPasswordModel model = new CompleteForgotPasswordModel();
            model.ResetToken = resetToken;
            return View(model);
        }

        [HttpPost]
        public ActionResult CompleteForgotPassword(CompleteForgotPasswordModel model)
        {
            var changePassword = WebMatrix.WebData.WebSecurity.ResetPassword(model.ResetToken, model.NewPassword);
            if (changePassword == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("ForgotPassword", "Account");
            }
        }
        [AllowAnonymous]
        public ActionResult RegistrationComplete()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult RegistrationComplete(string id, string email)
        {
           if( WebMatrix.WebData.WebSecurity.ConfirmAccount(email, id))
            {
                ViewBag.Confirmed = true;
            }
            return View();
        }



        //GET Accout/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerModel model)
        {
           if( Membership.ValidateUser(model.Email, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Email, true);
            }
            else
            {
                ModelState.AddModelError("Email", "Username and/or Password are Incorrect");
            }
            return RedirectToAction("Index", "Home");
        }
            
    }
}


 