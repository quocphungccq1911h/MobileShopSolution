using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface IRoleAdminService
    {
        Task<ApiResult<List<RoleVM>>> GetAllRole();
    }
}
