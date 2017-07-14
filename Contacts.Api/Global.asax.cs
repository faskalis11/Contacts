using contacts.Api;
using Contacts.Api.App_Start;
using System.Web;
using System.Web.Http;

namespace FirstWebApplication.Api
{
    public class WebApiApplication : HttpApplication
    {

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ContainerConfig.Register();
        }
    }
}
