using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface IUserAdminService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest request);
        Task<ApiResult<UserVm>> GetUserById(Guid id);
        Task<ApiResult<bool>> UpdateUser(Guid id ,UserUpdateRequest request);
        Task<ApiResult<bool>> DeleteUser(Guid id);
        Task<ApiResult<bool>> AssignRole(Guid id, RoleAssignRequest request);
    }
}
