using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Application.System.NavigationMenu;
using MobileShop.ViewModels.System.NavigationMernu;
using System.Threading.Tasks;

namespace MobileShop.WebAPI.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class NavigationMenusController : ControllerBase
    {
        #region Fields
        private readonly INavigationMenuService _navigationMenuService;
        #endregion

        #region Ctors
        public NavigationMenusController(INavigationMenuService navigationMenuService)
        {
            _navigationMenuService = navigationMenuService;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> AddNavigationMenu([FromBody] NavigationMenuRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _navigationMenuService.AddMenuNavigation(request);
            if(response.IsSuccessed)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
        [HttpGet]
        public IActionResult GetListNavigationMenus()
        {
            var response = _navigationMenuService.GetListNavigationMenus();
            return Ok(response);
        }
        #endregion

    }
}
