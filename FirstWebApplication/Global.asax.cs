using FirstWebApplication.Data.Models;
using FirstWebApplication.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FirstWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContactRepository contactRepository = new ContactRepository();

            Contact contact = new Contact()
            {
                Email = "aaa@aa.lt",
                Name = "Aaa",
                Phone = "861485784"
            };

            contactRepository.Create(contact);

            contact = new Contact()
            {
                Email = "bbb@bb.lt",
                Name = "bbb",
                Phone = "157869432"
            };

            contactRepository.Create(contact);
        }
    }
}
