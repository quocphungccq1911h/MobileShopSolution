using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.ApiIntergration.Interfaces;
using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobileShop.ApiIntergration
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(
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
