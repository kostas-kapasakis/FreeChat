using Autofac;
using System.Reflection;

namespace FreeChat.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("FreeChat.Persistence"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }
    }
}