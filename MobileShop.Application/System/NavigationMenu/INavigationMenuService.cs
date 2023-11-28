using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.NavigationMernu;
using System.Threading.Tasks;

namespace MobileShop.Application.System.NavigationMenu
{
    public interface INavigationMenuService
    {
        Task<ApiResult<bool>> AddMenuNavigation(NavigationMenuRequest request);
    }
}
