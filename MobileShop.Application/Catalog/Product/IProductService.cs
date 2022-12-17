﻿using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.Application.Catalog.Product
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<List<ProductVm>> GetAll();
        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);
    }
}
