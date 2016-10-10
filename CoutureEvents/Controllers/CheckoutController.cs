using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoutureEvents.Controllers
{
    public class CheckoutController : Controller
    {   // GET: Checkout
        public ActionResult Index()
        {

            Models.CheckoutModel model = new Models.CheckoutModel();

            return View();

        }


        [HttpPost]
        public ActionResult Index(Models.CheckoutModel model)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Recipt");
            }
            else
            {
                ModelState.AddModelError("anything", "Unable to checkout. Fix the errors");
                return View(model);
            }

          
            
        }
    }
}