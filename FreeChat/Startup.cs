using FreeChat.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            CreateRoles();
        }

        private void CreateRoles()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (roleManager.RoleExists("Admin")) return;
            var role = new IdentityRole { Name = "Admin" };
            roleManager.Create(role);

            var user = new ApplicationUser
            {
                UserName = "adminakos123",
                Email = "adminakos123@gmail.com"
            };

            var userPsw = $"Admin!@3";

            var checkUser = userManager.Create(user, userPsw);

            if (checkUser.Succeeded)
            {
                var verdict = userManager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
