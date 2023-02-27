using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.ApiIntergration.Interfaces
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleVM>>> GetAllRole();
    }
}
