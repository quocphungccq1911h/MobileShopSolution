
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public class LanguageAdminService : BaseAdminService ,ILanguageAdminService
    {
        public LanguageAdminService(
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor, 
            IHttpClientFactory httpContextFactory)
            : base(httpContextFactory, httpContextAccessor, configuration) { }
        public async Task<ApiResult<List<LanguageVM>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguageVM>>>("/api/languages");
        }
    }
}
