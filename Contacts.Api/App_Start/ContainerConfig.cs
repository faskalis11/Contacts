using Autofac;
using Autofac.Integration.WebApi;
using Contacts.Api.API;
using Contacts.Api.Controllers;
using Contacts.Data.ContactAPI;
using Contacts.Data.Entities;
using Contacts.Data.Repositories.Database;
using Contacts.Data.Repository.Database;
using System.Reflection;
using System.Web.Http;

namespace Contacts.Api.App_Start
{
    public class ContainerConfig
    {
        private static IContainer Container { get; set; }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DataContext>().InstancePerRequest();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerRequest();
            builder.RegisterType<MessageRepository>().As<IMessageRepository>().InstancePerRequest();
            // builder.RegisterType<> 
            builder.RegisterType<SmsController>().As<ISmsSender>().InstancePerRequest();
            builder.RegisterType<EmailController>().As<IEmailSender>().InstancePerRequest();
            Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}