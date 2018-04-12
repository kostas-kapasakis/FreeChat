using Autofac;
using System.Reflection;

namespace FreeChat.Web.Modules
{
    public class UnitOfWorkModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("FreeChat.Core"), Assembly.Load("FreeChat.Persistence"))
                .Where(t => t.Name.EndsWith("UnitOfWork"))
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }
    }
}