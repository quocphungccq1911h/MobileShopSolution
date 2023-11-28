using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileShop.Data.Entities;

namespace MobileShop.Data.Configurations
{
    public class NavigationMenuConfiguration : IEntityTypeConfiguration<NavigationMenu>
    {
        public void Configure(EntityTypeBuilder<NavigationMenu> builder)
        {
            builder.ToTable("NavigationMenu");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=>x.Name).IsRequired();
        }
    }
}
