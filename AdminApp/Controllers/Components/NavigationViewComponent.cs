using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.AdminApp.Models;
using MobileShop.ApiIntergration.Interfaces;
using MobileShop.Utilities.Constants;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;
        public NavigationViewComponent(ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageApiClient.GetAll();
            var navigationVm = new NavigationVM()
            {
                CurrentLanguageId = HttpContext.Session.GetString(SystemConstans.AppSetting.DefaultLanguageId),
                Languages = languages.ResultObj
            };
            return View("Default", navigationVm);
        }
    }
}
