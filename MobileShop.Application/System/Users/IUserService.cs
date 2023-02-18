using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Users;
using System;
using System.Threading.Tasks;

namespace MobileShop.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<UserVm>> GetUserById(Guid id);
        Task<ApiResult<bool>> DeleteUser(Guid id);
        Task<ApiResult<bool>> AssignRole(Guid id, RoleAssignRequest request);
    }
}
