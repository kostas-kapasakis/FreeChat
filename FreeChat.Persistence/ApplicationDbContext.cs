using System.Data.Entity;
using FreeChat.Core.Contracts;
using FreeChat.Core.Models;
using FreeChat.Core.Models.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FreeChat.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,IDbContext
    {
        public DbSet<Topics> Topics { get; set; }
        public DbSet<UserConnections> UserConnections { get; set; }
        public DbSet<ConnectedUsers> ConnectedUsers { get; set; }
        public DbSet<MainCategories> MainCategories { get; set; }

        public ApplicationDbContext()
            : base((string) "DefaultConnection", (bool) false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}