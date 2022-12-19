using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.Application.Catalog.Product
{
    public interface IProductService
    {
        Task<List<ProductVm>> GetAll(string languageId);
        Task<PagedResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request);
    }
}
