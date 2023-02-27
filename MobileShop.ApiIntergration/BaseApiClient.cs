using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MobileShop.Utilities.Constants;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace MobileShop.ApiIntergration
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        protected BaseApiClient(
            IHttpClientFactory httpClientFactory,
         IHttpContextAccessor httpContextAccessor,
         IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstans.AppSetting.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstans.AppSetting.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
        protected async Task<TResponse> PostAsync<TResponse>(string url, object request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstans.AppSetting.Token);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstans.AppSetting.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.PostAsync(url, httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObj = (TResponse)JsonConvert.DeserializeObject(body, typeof(TResponse));
                return myDeserializedObj;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }
    }
}
