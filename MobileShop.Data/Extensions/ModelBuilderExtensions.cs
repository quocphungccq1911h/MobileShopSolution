using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MobileShop.Data.Entities;
using MobileShop.Data.Enum;
using System;

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
                    SortOrder = 1,
                    Status = Status.Active
                },
                new Category()
                {
                    Id = 2,
                    IsShowHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active
                });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Máy tính xách tay", LanguageId = "vi-VN", SeoAlias = "may-tinh-xach-tay", SeoDescription = "Sản phẩm máy tính xách tay", SeoTitle = "Sản phẩm máy tính xách tay" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Laptop", LanguageId = "en-US", SeoAlias = "laptop", SeoDescription = "Product is laptop", SeoTitle = "Product is laptop" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Điện thoại", LanguageId = "vi-VN", SeoAlias = "dien-thoai", SeoDescription = "Điện thoại thông minh", SeoTitle = "Điện thoại thông minh" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Cellphone", LanguageId = "en-US", SeoAlias = "cell-phone", SeoDescription = "The cellphone", SeoTitle = "The cellphone" }
                    );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    CreateDate = DateTime.Now,
                    OriginalPrice = 15000000,
                    Price = 20000000,
                    Stock = 0,
                    ViewCount = 0,
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Máy tính bảng Huawei M3",
                    LanguageId = "vi-VN",
                    SeoAlias = "may-tinh-bang-huawei-m3",
                    SeoTitle = "Máy tính bảng Tablet Huawei M3",
                    Description = "Máy tính bảng Tablet Huawei M3",
                    Details = "Máy tính bảng Tablet Huawei M3"
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Tablet Huawei M3",
                    LanguageId = "en-US",
                    SeoAlias = "tablet-huawei-m3",
                    SeoTitle = "Tablet Huawei M3",
                    Description = "Tablet Huawei M3",
                    Details = "Tablet Huawei M3"
                });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );
            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "quocphungccq1911h@gmail.com",
                NormalizedEmail = "quocphungccq1911h@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "QuocPhung1994@"),
                SecurityStamp = string.Empty,
                FirstName = "Phung",
                LastName = "Phan",
                Dob = new DateTime(1994, 06, 11)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
