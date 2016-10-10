using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoutureEvents.Controllers
{
    public class ProductController : Controller
    {
        
        // GET: Product
        public ActionResult Index(int? id)
        {
            if (id == 1)
            {
                return View(new Models.ProductModel { Name = "Weekend Wedding production",
                    Price = 1800.00m,
                    Description = "Having a Wedding Day" +
                    "Coordinator is the new must have on your big day!  Your personal coordinator will ensure that everyone involved in your special" +
                    "day can relax and enjoy the precious moments you've been planning for months.",
                    ID = 1 });
                }

            else if(id == 2)
            {
                return View(new Models.ProductModel { Name = "Partial Wedding Planning",
                    Price = 2900.00m,
                    Description = "So you decided you want someone to manage your" +
                    "wedding day; someone to handle all the little things that leave you free to enjoy your special day. You realize you also might need additional help" +
                    "from now until your wedding day. Are you planning a wedding while working or from out-of-town and need someone to be your liaison to the venue and" +
                    "vendors? Our partial Wedding Planning service is for you",
                    ID = 2 });
            }

            if (id == 3)
            {
                return View(new Models.ProductModel
                {
                    Name = "Couture Signature Package",
                    Price = 4500.00m,
                    Description = "Engagement to Honeymoon coordination / direction, Unlimited phone calls and e - mails, " +
                    "Initial meeting to get an overview of wishes, colors, and desires A complete list of area professional" +
                    "vendors / ceremony / reception / rehearsal dinner Arrange appointments with professional vendors - attend final meetings" +
                    "Assist with selection of hair / make - up artist Provide a bridal emergency kit Assist the bride and attendants during dressing" +
                    "for the ceremony Coordinate with the florist Coordinate reception details:  Couple entrance First dance Cake cutting Toasting Departure",
                    ID = 3
                });
        }
            else
            {
                return View();
            }
           
        }


        public ActionResult List()
        {

            List<Models.ProductModel> model = new List<Models.ProductModel>();
            model.Add(new Models.ProductModel
            {
                Name = "Weekend Wedding production",
                Price = 1800.00m,
                Description = "Having a Wedding Day" +
                    "Coordinator is the new must have on your big day!  Your personal coordinator will ensure that everyone involved in your special" +
                    "day can relax and enjoy the precious moments you've been planning for months.",
                ID = 1
            });

            model.Add(new Models.ProductModel
            {
                Name = "Partial Wedding Planning",
                Price = 2900.00m,
                Description = "So you decided you want someone to manage your" +
                    "wedding day; someone to handle all the little things that leave you free to enjoy your special day. You realize you also might need additional help" +
                    "from now until your wedding day. Are you planning a wedding while working or from out-of-town and need someone to be your liaison to the venue and" +
                    "vendors? Our partial Wedding Planning service is for you",
                ID = 2
            });

            model.Add(new Models.ProductModel
            {
                Name = "Couture Signature Package",
                Price = 4500.00m,
                Description = "Engagement to Honeymoon coordination / direction, Unlimited phone calls and e - mails, " +
                    "Initial meeting to get an overview of wishes, colors, and desires A complete list of area professional" +
                    "vendors / ceremony / reception / rehearsal dinner Arrange appointments with professional vendors - attend final meetings" +
                    "Assist with selection of hair / make - up artist Provide a bridal emergency kit Assist the bride and attendants during dressing" +
                    "for the ceremony Coordinate with the florist Coordinate reception details:  Couple entrance First dance Cake cutting Toasting Departure",
                ID = 3
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Models.ProductModel model)
        {

            //Add product to cart in database
            return RedirectToAction("Index", "Checkout");
        }

    }
}