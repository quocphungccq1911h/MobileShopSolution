using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.Utilities.Constants;
using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public class ProductAdminService : BaseAdminService, IProductAdminService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public ProductAdminService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstans.AppSetting.Token);
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstans.AppSetting.DefaultLanguageId);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstans.AppSetting.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var requestContent = new MultipartFormDataContent();
            if(request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
            }
            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(request.Name.ToString()), "name");
            requestContent.Add(new StringContent(request.Description.ToString()), "description");

            requestContent.Add(new StringContent(request.Details.ToString()), "details");
            requestContent.Add(new StringContent(request.SeoDescription.ToString() ?? ""), "SeoDescription");
            requestContent.Add(new StringContent(request.SeoTitle.ToString() ?? ""), "seoTitle");
            requestContent.Add(new StringContent(request.SeoAlias.ToString() ?? ""), "seoAlias");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/product/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ProductVm>> GetPaging(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>($"/api/Product/paging?Keyword={request.Keyword}&LanguageId={request.LanguageId}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}
