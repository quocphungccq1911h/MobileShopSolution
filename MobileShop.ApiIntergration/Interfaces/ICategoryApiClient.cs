using MobileShop.ViewModels.Catalog.Categories;
using MobileShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.ApiIntergration.Interfaces
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVM>> GetAllCategory(string languageId);
        Task<bool> CreateCategory(CategoryCreateRequest request); 
    }
}
