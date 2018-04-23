using FreeChat.Core.Contracts;
using FreeChat.Core.Models.Domain;
using FreeChat.Persistence.FluentConfigurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FreeChat.Persistence
{

    public class FreeChatContext : IdentityDbContext<User>, IDbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public DbSet<ConnectedUser> ConnectedUsers { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Message> Messages { get; set; }


        public FreeChatContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer<FreeChatContext>(new DbInitializer<FreeChatContext>());
        }

        public static FreeChatContext Create()
        {
            return new FreeChatContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MainCategoryConfiguration());
            modelBuilder.Configurations.Add(new ConnectedUserConfiguration());
            modelBuilder.Configurations.Add(new TopicConfiguration());
            modelBuilder.Configurations.Add(new UserConnectionConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}