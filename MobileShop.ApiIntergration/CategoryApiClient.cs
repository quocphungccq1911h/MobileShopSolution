using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.ApiIntergration.Interfaces;
using MobileShop.ViewModels.Catalog.Categories;
using MobileShop.ViewModels.Common;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileShop.ApiIntergration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration) { }

        public async Task<bool> CreateCategory(CategoryCreateRequest request)
        {
            return await PostAsync<bool>($"/api/Categories", request);
        }

        public async Task<List<CategoryVM>> GetAllCategory(string languageId)
        {
            var res = await GetAsync<List<CategoryVM>>($"/api/categories?languageId={languageId}");
            return res;
        }
    }
}
