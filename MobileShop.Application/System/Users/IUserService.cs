using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace MobileShop.Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
