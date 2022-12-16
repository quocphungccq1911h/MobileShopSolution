using Microsoft.EntityFrameworkCore;
using MobileShop.Data.Entities;
using MobileShop.Data.Enum;

namespace MobileShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of MobileShop" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of MobileShop" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of MobileShop" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowHome = true,
                    ParentId = null,
                    SordOrder = 1,
                    Status = Status.Active
                },
                new Category()
                {
                    Id = 2,
                    IsShowHome = true,
                    ParentId = null,
                    SordOrder = 2,
                    Status = Status.Active
                });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Máy tính xách tay", LanguageId = "vi-VN", SeoAlias = "may-tinh-xach-tay", SeoDescription = "Sản phẩm máy tính xách tay", SeoTitle = "Sản phẩm máy tính xách tay" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Laptop", LanguageId = "en-US", SeoAlias = "laptop", SeoDescription = "Product is laptop", SeoTitle = "Product is laptop" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Điện thoại", LanguageId = "vi-VN", SeoAlias = "dien-thoai", SeoDescription = "Điện thoại thông minh", SeoTitle = "Điện thoại thông minh" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Cellphone", LanguageId = "en-US", SeoAlias = "cell-phone", SeoDescription = "The cellphone", SeoTitle = "The cellphone" }
                    );
        }
    }
}
