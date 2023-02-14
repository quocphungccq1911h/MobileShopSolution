using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface IUserAdminService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
    }
}
