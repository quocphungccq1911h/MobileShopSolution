using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface ILanguageAdminService
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
