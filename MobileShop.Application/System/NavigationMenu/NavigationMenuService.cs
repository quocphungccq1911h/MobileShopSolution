using MobileShop.Data;
using MobileShop.Utilities.Extensions;
using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.NavigationMernu;
using System.Collections.Generic;
using System.Linq;
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
            _context.NavigationMenus.Add(model);
            var res = await _context.SaveChangesAsync();
            if(res > 0)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>(ConfigConstantError.ErrorMessageAdd);
        }

        public List<NavigationMenuVM> GetListNavigationMenus()
        {
            var listMenu = _context.NavigationMenus.ToList();
            var nodedata = this.GetHierarchy(listMenu, 0);
            if (nodedata is null)
            {
                return null;
            }
            return nodedata;
        }
        #endregion

        #region Helper
        private Data.Entities.NavigationMenu BuildNavigationMenuRequest(NavigationMenuRequest model)
        {
            return new Data.Entities.NavigationMenu()
            {
                Name = model.Name,
                Icon = model.Icon ?? "",
                ParentId = model.ParentId ?? 0,
                Alias = MobileShopExtension.GenSlugHelper(model.Name)
            };
        }
        private List<NavigationMenuVM> GetHierarchy(List<Data.Entities.NavigationMenu> data, int? parentId)
        {
            var item = data.Any(x => x.ParentId == parentId);
            if (!item)
            {
                return null;
            }
            var res = data.Where(x => x.ParentId == parentId).Select(c => new NavigationMenuVM
            {
                Id = c.Id,
                Icon = c.Icon,
                ParentId = c.ParentId,
                Alias = c.Alias,
                Name = c.Name,
                Items = GetHierarchy(data, c.Id)
            }).ToList();
            return res;
        }
        #endregion
    }
}
