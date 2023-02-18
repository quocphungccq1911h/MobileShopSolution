using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Roles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public class RoleAdminService : IRoleAdminService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public RoleAdminService(
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration
            )
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResult<List<RoleVM>>> GetAllRole()
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync($"/api/roles");
            var body = await response.Content.ReadAsStringAsync();
            if(response.IsSuccessStatusCode)
            {
                List<RoleVM> myDeserializedObjList = (List<RoleVM>)JsonConvert.DeserializeObject(body, typeof(List<RoleVM>));
                return new ApiSuccessResult<List<RoleVM>>(myDeserializedObjList);
            }
            return JsonConvert.DeserializeObject<ApiErrorResult<List<RoleVM>>>(body);
        }
    }
}
