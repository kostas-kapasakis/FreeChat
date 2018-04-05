using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FreeChat.Modules;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FreeChat.Core.Contracts.Services;
using FreeChat.Core.Models;
using FreeChat.Core.Services;
using FreeChat.Persistence;

namespace FreeChat
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {



            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac Configuration
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());

            builder.RegisterType<TopicsService>().As<ITopicsService>();
            builder.RegisterType<ApplicationDbContext>().AsSelf();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); //Set the MVC DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver


        }
    }
}
