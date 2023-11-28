using MobileShop.Data;
using MobileShop.Utilities.Extensions;
using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.NavigationMernu;
using System.Threading.Tasks;

namespace MobileShop.Application.System.NavigationMenu
{
    public class NavigationMenuService : INavigationMenuService
    {
        #region Fields
        private readonly MobileShopDbContext _context;
        #endregion

        #region Ctors
        public NavigationMenuService(MobileShopDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<ApiResult<bool>> AddMenuNavigation(NavigationMenuRequest request)
        {
            var model = this.BuildNavigationMenuRequest(request);
            var response = _context.NavigationMenus.Add(model);
        }
        #endregion

        #region Helper
        private Data.Entities.NavigationMenu BuildNavigationMenuRequest(NavigationMenuRequest model)
        {
            return new Data.Entities.NavigationMenu()
            {
                Name = model.Name,
                Icon = model.Icon,
                ParentId = model.ParentId,
                Alias = MobileShopExtension.GenSlugHelper(model.Name)
            };
        }
        #endregion
    }
}
