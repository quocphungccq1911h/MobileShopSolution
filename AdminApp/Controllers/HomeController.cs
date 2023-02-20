using AdminApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobileShop.AdminApp.Controllers;
using MobileShop.AdminApp.Models;
using MobileShop.Utilities.Constants;
using System.Diagnostics;

namespace AdminApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Language(NavigationVM navigationVM)
        {
            HttpContext.Session.SetString(SystemConstans.AppSetting.DefaultLanguageId, navigationVM.CurrentLanguageId);
            return RedirectToAction("Index");
        }
    }
}
