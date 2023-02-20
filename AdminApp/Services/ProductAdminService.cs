using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public class ProductAdminService : BaseAdminService, IProductAdminService
    {
        public ProductAdminService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration) { }
        public async Task<PagedResult<ProductVm>> GetPaging(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>($"/api/Product/paging?Keyword={request.Keyword}&LanguageId={request.LanguageId}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}
