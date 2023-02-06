using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface IUserAdminService
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
