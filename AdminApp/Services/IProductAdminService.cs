using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface IProductAdminService
    {
        Task<PagedResult<ProductVm>> GetPaging(GetManageProductPagingRequest request);
    }
}
