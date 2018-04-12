using FreeChat.Core.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace FreeChat.Persistence.FluentConfigurations
{
    public class TopicConfiguration : EntityTypeConfiguration<Topic>
    {
        public TopicConfiguration()
        {
            Property(n => n.Name)
                .HasMaxLength(50)
                .IsRequired();


            Property(g => g.Genre)
                .HasMaxLength(50)
                .IsRequired();

            Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(500);

            HasRequired(u => u.UserCreator);

            HasRequired(m => m.MainCategory);



        }
    }
}
