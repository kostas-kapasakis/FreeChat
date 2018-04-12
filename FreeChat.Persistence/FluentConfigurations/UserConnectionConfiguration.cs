using FreeChat.Core.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace FreeChat.Persistence.FluentConfigurations
{
    public class UserConnectionConfiguration : EntityTypeConfiguration<UserConnection>
    {
        public UserConnectionConfiguration()
        {
            HasRequired(p => p.User);

            HasRequired(u => u.ConnectedUser);
        }

    }
}
