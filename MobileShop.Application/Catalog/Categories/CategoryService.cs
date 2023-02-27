using MobileShop.Data;
using MobileShop.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MobileShop.ViewModels.Common;

namespace MobileShop.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly MobileShopDbContext _context;
        public CategoryService(MobileShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var category = new Data.Entities.Category()
            {
                IsShowHome = request.IsShowHome,
                SortOrder = request.SortOrder,
                ParentId = request.ParentId,
                Status = request.Status,
                CategoryTranslations = new List<Data.Entities.CategoryTranslation>
                {
                    new Data.Entities.CategoryTranslation()
                    {
                        Name = request.Name,
                        SeoDescription= request.SeoDescription,
                        SeoTitle= request.SeoTitle,
                        LanguageId= request.LanguageId,
                        SeoAlias = request.SeoAlias,
                    }
                }
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<List<CategoryVM>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                            //join pic in _context.ProductInCategories on c.Id equals pic.CategoryId
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVM()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToListAsync();
        }
    }
}
