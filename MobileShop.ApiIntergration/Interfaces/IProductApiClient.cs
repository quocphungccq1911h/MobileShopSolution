using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System.Threading.Tasks;

namespace MobileShop.ApiIntergration.Interfaces
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductVm>> GetPaging(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<ApiResult<bool>> AssignCategory(int id, CategoryAssignRequest request);
        Task<ApiResult<ProductVm>> GetProductById(int id, string languageId);
    }
}
