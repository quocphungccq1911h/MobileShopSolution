using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface IUserAdminService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVm>> GetUserPaging(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest request);
    }
}
