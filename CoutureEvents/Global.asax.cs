using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace CoutureEvents
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection("CESecurity", "Customer", "ID", "Email", true);

           if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }

            //Roles.AddUserToRole("claytonhalaska@gmail.com", "Admin");

        }
    }
}
