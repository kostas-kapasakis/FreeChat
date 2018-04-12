using FreeChat.Core.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace FreeChat.Persistence.FluentConfigurations
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            HasKey(c => c.Id);

            Property(m => m.MessageSent)
                .HasMaxLength(5000);
        }
    }
}
