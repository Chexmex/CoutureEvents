using CoutureEvents.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            using (CoutureEvents.Models.CEdatabaseEntities1 entities = new Models.CEdatabaseEntities1())
            {
                if (ModelState.IsValid)
                {
                    var services = entities.Services.Select(x => new ProductModel
                    {
                        ServiceID = x.ServiceID,
                        Name = x.Name,
                        Price = x.Price,
                        Description = x.Description

                    }).Single(x => x.ServiceID == id);

                    return View(services);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
        }

        [HttpPost]
        public ActionResult Index(ProductModel model)
        {
      

            using (CoutureEvents.Models.CEdatabaseEntities1 entities = new Models.CEdatabaseEntities1())
            {
                ProductModel s = new ProductModel();
                s.Name = model.Name;
                s.Price = model.Price ?? 0;
                s.Description = model.Description;



                Response.Cookies.Add(new HttpCookie("ServiceID", model.ServiceID.ToString()));
            }
            return RedirectToAction("Checkout", "Product");

        }


        //GET List of all products
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
                ServiceID = 2
            });

            model.Add(new Models.ProductModel
            {
                Name = "Partial Wedding Planning",
                Price = 2900.00m,
                Description = "So you decided you want someone to manage your" +
                    "wedding day; someone to handle all the little things that leave you free to enjoy your special day. You realize you also might need additional help" +
                    "from now until your wedding day. Are you planning a wedding while working or from out-of-town and need someone to be your liaison to the venue and" +
                    "vendors? Our partial Wedding Planning service is for you",
                ServiceID = 1
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
                ServiceID = 3
            });
            return View(model);
        }


        public ActionResult Checkout()
        {
            using (CoutureEvents.Models.CEdatabaseEntities1 entities = new Models.CEdatabaseEntities1())
            {
                ProposalModel Proposal = new ProposalModel();

                if (Request.Cookies["ServiceID"] == null)
                {
                    return RedirectToAction("List");
                }

                else
                {
                    Customer c = entities.Customers.Single(x => x.Email == User.Identity.Name);
                    Proposal.Customer = new CustomerModel
                    {
                        Email = c.Email,
                        City = c.City,
                        Address = c.Address,
                        BrideFirstName = c.BrideFirstName,
                        BrideLastName = c.BrideLastName,
                        GroomFirstName = c.GroomFirstName,
                        GroomLastName = c.GroomLastName,
                        ID = c.ID,
                        NumberOfBridesmaids = c.NumberOfBridesmaids,
                        NumberOfGroomsmen = c.NumberOfGroomsmen,
                        NumberOfGuests = c.NumberOfGuests,
                        PhoneNumber = c.PhoneNumber,
                        WeddingDate = c.WeddingDate,
                        //Password = c.Password


                    };
                    int id = int.Parse(Request.Cookies["ServiceID"].Value);
                    Service s = entities.Services.Single(x => x.ServiceID == id);

                    Proposal.Service = new ProductModel
                    {
                        Description = s.Description,
                        Name = s.Name,
                        Price = s.Price,
                        ServiceID = s.ServiceID
                    };

                }

                entities.SaveChanges();




                return View(Proposal);
            }
        }


        [HttpPost]
        public ActionResult Checkout(ProposalModel model)
        {

            string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
            SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

            SendGrid.Helpers.Mail.Email from = new SendGrid.Helpers.Mail.Email("Suzanne@coutureEventsChicago.com");
            string subject = "Couture Events: New Client!";
            SendGrid.Helpers.Mail.Email to = new SendGrid.Helpers.Mail.Email("Suzanne@coutureEventsChicago.com");

            Content content = new Content("text/html", " ");
            Mail mail = new Mail(from, subject, to, content);

            mail.TemplateId = "13a5ec2f-0260-4134-a3a2-aeacbe6882ec";
            mail.Personalization[0].AddSubstitution("-brideName-",  model.Customer.BrideFirstName + "  " + model.Customer.BrideLastName);
            mail.Personalization[0].AddSubstitution("-groomName-", model.Customer.GroomFirstName + " " + model.Customer.GroomLastName);
            mail.Personalization[0].AddSubstitution("-phoneNumber-", model.Customer.PhoneNumber);
            mail.Personalization[0].AddSubstitution("-email-", model.Customer.Email);
            mail.Personalization[0].AddSubstitution("-weddingDate-", model.Customer.WeddingDate.ToString());
            mail.Personalization[0].AddSubstitution("-numberOfGuests-", model.Customer.NumberOfGuests.ToString());
            mail.Personalization[0].AddSubstitution("-serviceName-", model.Service.Name);
            mail.Personalization[0].AddSubstitution("-address-", model.Customer.Address);
            mail.Personalization[0].AddSubstitution("-groomsmen-", model.Customer.NumberOfGroomsmen.ToString());
            mail.Personalization[0].AddSubstitution("-serviceName-", model.Customer.NumberOfBridesmaids.ToString());

            client.client.mail.send.post(requestBody: mail.Get());
            return RedirectToAction("Index", "Home");
        }
    }
}