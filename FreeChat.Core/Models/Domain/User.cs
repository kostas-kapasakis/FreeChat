using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FreeChat.Core.Models.Domain
{
    public class User : IdentityUser
    {

        public bool Active { get; set; }

        public int RoomsLeft { get; set; } = 10;

        public string Role { get; set; }

        public IList<UserConnection> UserConnections { get; set; }

        public IList<Topic> TopicsConnected { get; set; }

        public User()
        {
            UserConnections = new List<UserConnection>();
            TopicsConnected = new List<Topic>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

    }


}