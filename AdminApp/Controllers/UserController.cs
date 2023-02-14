using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.AdminApp.Controllers;
using MobileShop.AdminApp.Services;
using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAdminService _userAdminService;
        public UserController(IUserAdminService userAdminService)
        {
            _userAdminService = userAdminService;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var session = HttpContext.Session.GetString("Token");
            var request = new GetUserPagingRequest()
            {
                BearerToken = session,
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var users = await _userAdminService.GetUserPaging(request);
            return View(users.ResultObj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userAdminService.RegisterUser(request);
            if (result.IsSuccessed)
            {
                return RedirectToAction("Index");
            }
            return View(request);
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("Token");
            return RedirectToAction("Login", "Login");
        }
    }
}
