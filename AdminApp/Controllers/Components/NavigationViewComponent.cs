using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.AdminApp.Models;
using MobileShop.AdminApp.Services;
using MobileShop.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageAdminService _languageAdminService;
        public NavigationViewComponent(ILanguageAdminService languageAdminService)
        {
            _languageAdminService = languageAdminService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageAdminService.GetAll();
            var navigationVm = new NavigationVM()
            {
                CurrentLanguageId = HttpContext.Session.GetString(SystemConstans.AppSetting.DefaultLanguageId),
                Languages = languages.ResultObj
            };
            return View("Default", navigationVm);
        }
    }
}
