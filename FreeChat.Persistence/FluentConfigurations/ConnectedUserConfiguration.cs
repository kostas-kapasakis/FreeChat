using FreeChat.Core.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace FreeChat.Persistence.FluentConfigurations
{
    public class ConnectedUserConfiguration : EntityTypeConfiguration<ConnectedUser>
    {
        public ConnectedUserConfiguration()
        {
            HasKey(k => k.Id);

            Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(50);

            HasMany(c => c.UserConnections)
                .WithRequired(c => c.ConnectedUser)
                .HasForeignKey(c => c.ConnectedUserId);



        }
    }
}
