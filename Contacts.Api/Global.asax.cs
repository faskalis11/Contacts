﻿using contacts.Api;
using System.Web;
using System.Web.Http;

namespace FirstWebApplication.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
