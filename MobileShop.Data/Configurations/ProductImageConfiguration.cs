using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MobileShop.Data.Entities;

namespace MobileShop.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
        }
    }
}
