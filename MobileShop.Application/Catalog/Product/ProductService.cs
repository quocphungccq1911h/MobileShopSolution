using Microsoft.EntityFrameworkCore;
using MobileShop.Data;
using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
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
        public async Task<List<ProductVm>> GetAll(string languageId)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _context.ProductInCategories on p.Id equals pc.ProductId
                        join c in _context.Categories on pc.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pc };
            var data = await query.Select(x => new ProductVm()
            {
                Id = x.p.Id,
                Price = x.p.Price,
                OriginalPrice = x.p.OriginalPrice,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount,
                DateCreated = x.p.CreateDate,
                Name = x.pt.Name,
                Description = x.pt.Description,
                Details = x.pt.Details,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                SeoAlias = x.pt.SeoAlias,
                LanguageId = x.pt.LanguageId,
                //Categories = x.c.ProductInCategories.Where(d => d.CategoryId == x.c.Id).Select(e => e.CategoryId).ToList(),
            }).ToListAsync();
            return data;
        }
        public async Task<PagedResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            // Select and Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _context.ProductInCategories on p.Id equals pc.ProductId
                        //join c in _context.Categories on pc.CategoryId equals c.Id
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt, pc };
            // Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(x => x.pc.CategoryId == request.CategoryId);
            }
            // paging
            var totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageSize - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductVm()
                {
                    Id = x.p.Id,
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.CreateDate,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    SeoAlias = x.pt.SeoAlias,
                    LanguageId = x.pt.LanguageId,
                    //Categories = x.c.ProductInCategories.Where(d => d.CategoryId == x.c.Id).Select(e => e.CategoryId).ToList(),
                }).ToListAsync();
            // select and projection
            var pageResult = new PagedResult<ProductVm>
            {
                TotalRecords = totalRow,
                Items = data
            };
            return pageResult;
        }
    }
}
