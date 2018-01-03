using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreeChat.Startup))]
namespace FreeChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
