using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.Application.Catalog.Product
{
    public class ProductService : IProductService
    {
        private readonly MobileShopDbContext _context;
        public ProductService(MobileShopDbContext context)
        {
            _context = context;
        }
        public Task<List<ProductVm>> GetAll()
        {
            return _context.Products.Select(x => new ProductVm()
            {
                Id = x.Id,
                Price = x.Price,
                OriginalPrice = x.OriginalPrice,
                Stock = x.Stock,
                ViewCount = x.ViewCount,
                DateCreated = x.CreateDate,
                Name = x.ProductTranslations.FirstOrDefault().Name,
                Description = x.ProductTranslations.FirstOrDefault().Description,
                Details = x.ProductTranslations.FirstOrDefault().Details,
                SeoDescription = x.ProductTranslations.FirstOrDefault().SeoDescription,
                SeoTitle = x.ProductTranslations.FirstOrDefault().SeoTitle,
                SeoAlias = x.ProductTranslations.FirstOrDefault().SeoAlias,
                LanguageId = x.ProductTranslations.FirstOrDefault().LanguageId,
                ThumbnailImage = x.ProductImages.FirstOrDefault().ImagePath,
                Categories = x.ProductInCategories.Select(c=>c.CategoryId).ToList()
            }).ToListAsync();
        }
    }
}
