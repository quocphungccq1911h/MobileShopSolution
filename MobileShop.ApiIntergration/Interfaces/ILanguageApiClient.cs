using MobileShop.ViewModels.Common;
using MobileShop.ViewModels.System.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.ApiIntergration.Interfaces
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageVM>>> GetAll();
    }
}
