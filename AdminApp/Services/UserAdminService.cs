using Microsoft.AspNetCore.Http;
using MobileShop.ViewModels.System.Users;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public class UserAdminService : IUserAdminService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserAdminService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("/api/Users/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
