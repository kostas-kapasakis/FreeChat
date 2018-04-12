using System.Reflection;
using Autofac;

namespace FreeChat.Web.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("FreeChat.Persistence"))
                .Where(t => t.Name.EndsWith("Repository") && t.Name.EndsWith("UnitOfWork"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }
    }
}