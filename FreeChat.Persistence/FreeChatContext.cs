using System.Data.Entity;
using FreeChat.Core.Contracts;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreeChat.Persistence
{
    public class FreeChatContext : IdentityDbContext<ApplicationUser>,IDbContext
    {
        public DbSet<Topics> Topics { get; set; }
        public DbSet<UserConnections> UserConnections { get; set; }
        public DbSet<ConnectedUsers> ConnectedUsers { get; set; }
        public DbSet<MainCategories> MainCategories { get; set; }

        public FreeChatContext()
            : base((string) "DefaultConnection", (bool) false)
        {
        }

        public static FreeChatContext Create()
        {
            return new FreeChatContext();
        }
    }
}