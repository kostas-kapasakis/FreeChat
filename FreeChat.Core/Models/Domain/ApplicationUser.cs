using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FreeChat.Core.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {

        public bool Active { get; set; }

        public int RoomsLeft { get; set; }

        public string Role { get; set; }

        public IList<UserConnection> UserConnections { get; set; }

        public ApplicationUser()
        {
            UserConnections = new List<UserConnection>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

    }


}