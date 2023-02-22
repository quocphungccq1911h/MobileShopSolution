using MobileShop.Data;
using MobileShop.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MobileShop.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly MobileShopDbContext _context;
        public CategoryService(MobileShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join pic in _context.ProductInCategories on c.Id equals pic.CategoryId
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct, pic };
            return await query.Select(x => new CategoryVM()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToListAsync();
        }
    }
}
