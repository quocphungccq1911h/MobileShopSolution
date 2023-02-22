using MobileShop.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAll(string languageId);
    }
}
