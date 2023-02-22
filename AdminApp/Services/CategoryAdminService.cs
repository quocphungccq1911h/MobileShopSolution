using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public class CategoryAdminService : BaseAdminService, ICategoryAdminService
    {
        public CategoryAdminService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) 
            : base(httpClientFactory, httpContextAccessor, configuration) {}

        public async Task<List<CategoryVM>> GetAllCategory(string languageId)
        {
            var res = await GetAsync<List<CategoryVM>>($"/api/categories?languageId={languageId}");
            return res;
        }
    }
}
