using Autofac;
using System.Reflection;

namespace FreeChat.Web.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("FreeChat.Core"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .PreserveExistingDefaults()
                .InstancePerLifetimeScope();
        }
    }
}