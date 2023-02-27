using MobileShop.ViewModels.Catalog.Categories;
using MobileShop.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        // Create category
        Task<int> Create(CategoryCreateRequest request);
        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
