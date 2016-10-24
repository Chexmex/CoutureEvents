using CoutureEvents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace CoutureEvents.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
    

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Register(CustomerModel model)
        {
            if (WebMatrix.WebData.WebSecurity.UserExists(model.Email))
            {
                ModelState.AddModelError("Email", "Could not create a user with this email address");
            }

            else
            {
                WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password, new
                {
                    BrideFirstName = model.BrideFirstName,
                    BrideLastName = model.BrideLastName,
                    GroomFirstName = model.GroomFirstName,
                    GroomLastName = model.GroomLastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address = model.Address,
                    City = model.City,
                    WeddingDate = model.WeddingDate,
                    NumberOfGuests = model.NumberOfGuests,
                    NumberOfBridesmaids = model.NumberOfBridesmaids,

                }, false);
            }
            return RedirectToAction("Login", "Account");
        }


    }
}