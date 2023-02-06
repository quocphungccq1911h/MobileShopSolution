using Microsoft.AspNetCore.Mvc;
using MobileShop.AdminApp.Services;
using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAdminService _userAdminService;
        public UserController(IUserAdminService userAdminService)
        {
            _userAdminService= userAdminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var token = await _userAdminService.Authenticate(request);
            return View(token);
        }
    }
}
