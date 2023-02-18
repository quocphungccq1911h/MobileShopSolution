using MobileShop.ViewModels.System.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetAll();
    }
}
