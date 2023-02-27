using MobileShop.Data;
using MobileShop.Utilities.Exceptions;
using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using MobileShop.Application.Common;
using MobileShop.Data.Entities;

namespace MobileShop.Application.Catalog.Product
{
    public class ProductManageService : IProductManageService
    {
        private readonly MobileShopDbContext _context;
        private readonly IStorageService _storageService;
        public ProductManageService(MobileShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public Task<int> AddImages(int productId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return new ApiErrorResult<bool>($"Không tìm thấy sản phẩm với Id = {id}");
            }
            foreach (var category in request.Categories)
            {
                var productInCategory = await _context.ProductInCategories.FirstOrDefaultAsync(x => x.CategoryId == int.Parse(category.Id) && x.ProductId == id);
                if (productInCategory != null && category.Selected == false)
                {
                    _context.ProductInCategories.Remove(productInCategory);
                }
                else if (productInCategory == null && category.Selected)
                {
                    await _context.ProductInCategories.AddAsync(new ProductInCategory()
                    {
                        CategoryId = int.Parse(category.Id),
                        ProductId = id
                    });
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Data.Entities.Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                CreateDate = DateTime.Now,
                ProductTranslations = new List<Data.Entities.ProductTranslation>
                {
                    new Data.Entities.ProductTranslation
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        SeoAlias = request.SeoAlias,
                        LanguageId = request.LanguageId,
                    }
                }
            };
            // Save Image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<Data.Entities.ProductImage>()
                {
                    new Data.Entities.ProductImage()
                    {
                        Caption = "Thumbnail Image",
                        DateCreated = DateTime.Now,
                        FileSize = (int)request.ThumbnailImage.Length,
                        ImagePath = await SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new MobileShopException($"Cannot find product: {productId}");
            var images = _context.ProductImages.Where(x => x.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public Task<List<ProductVm>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            // Select and Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()
                        join c in _context.Categories on pic.CategoryId equals c.Id into picc
                        from c in picc.DefaultIfEmpty()
                        where pt.LanguageId == request.LanguageId
                        select new { p, pt, pic };
            // Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            }
            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            // Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
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
                }).ToListAsync();

            // Select and Projection
            var pageResult = new PagedResult<ProductVm>
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            return pageResult;
        }

        public Task<List<ProductImageVM>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<ProductVm>> GetProductById(int productId, string languageId)
        {
            var product = await _context.Products.FindAsync(productId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId && x.LanguageId == languageId);
            if (product == null) return new ApiErrorResult<ProductVm>($"Không thể tìm thấy sản phẩm với Id = {productId}");
            if (productTranslation == null) return new ApiErrorResult<ProductVm>($"Không thể tìm thấy sản phẩm với Id = {productId} với ngôn ngữ = {languageId}");
            var category = await (from c in _context.Categories
                                  join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                                  join pic in _context.ProductInCategories on c.Id equals pic.CategoryId
                                  where ct.LanguageId == languageId && pic.ProductId == productId
                                  select ct.Name).ToListAsync();
            var productVM = new ProductVm()
            {
                Id = product.Id,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                DateCreated = product.CreateDate,
                Name = productTranslation.Name,
                Description = productTranslation.Description,
                Details = productTranslation.Details,
                SeoDescription = productTranslation.SeoDescription,
                SeoTitle = productTranslation.SeoTitle,
                SeoAlias = productTranslation.SeoAlias,
                LanguageId = productTranslation.LanguageId,
                Categories = category
            };
            return new ApiSuccessResult<ProductVm>(productVM);
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if (product == null && productTranslations == null) throw new MobileShopException($"Cannot find a product with if: {request.Id}");
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Details = request.Details;
            productTranslations.Description = request.Description;
            // Save Image
            if (request.Thumbnail != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.IsDefault);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = (int)request.Thumbnail.Length;
                    thumbnailImage.ImagePath = await SaveFile(request.Thumbnail);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new MobileShopException($"Cannot find a product with if: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new MobileShopException($"Cannot find a product with if: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
