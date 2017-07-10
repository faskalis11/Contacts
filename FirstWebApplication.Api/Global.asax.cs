using FirstWebApplication.Data.Models;
using FirstWebApplication.Data.Repositories;
using System.Web;
using System.Web.Http;

namespace FirstWebApplication.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

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
