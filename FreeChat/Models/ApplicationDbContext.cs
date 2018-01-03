using FreeChat.Models.Domain;
using FreeChat.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FreeChat.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Topics> Topics { get; set; }
        public DbSet<UserConnections> UserConnections { get; set; }
        public DbSet<ConnectedUsers> ConnectedUsers { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}