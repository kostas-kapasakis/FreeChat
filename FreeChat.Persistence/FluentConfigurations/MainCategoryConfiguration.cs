using FreeChat.Core.Models.Domain;
using System.Data.Entity.ModelConfiguration;

namespace FreeChat.Persistence.FluentConfigurations
{
    public class MainCategoryConfiguration : EntityTypeConfiguration<MainCategory>
    {
        public MainCategoryConfiguration()
        {
            HasKey(k => k.Id);


            Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);

            Property(p => p.CategoryDescription)
                    .IsRequired()
                    .HasMaxLength(1000);


            Property(p => p.CategoryImage)
                .IsRequired()
                .HasMaxLength(3000);

            HasMany(t => t.Topics)
                .WithRequired(t => t.MainCategory)
                .HasForeignKey(t => t.MainCategoryId);

        }
    }
}
