using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FreeChat.Persistence;
using FreeChat.Web.Modules;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
namespace FreeChat.Web
{
    public static class InfrastructureConfiguration
    {
        public static void Configuration()
        {
            //Autofac Configuration
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired().InstancePerRequest(); ;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest(); ;

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new UnitOfWorkModule());

            builder.RegisterType<FreeChatContext>().AsSelf();


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container); //Set the WebApi DependencyResolver
        }

    }
}