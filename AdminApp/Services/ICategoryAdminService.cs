using MobileShop.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Services
{
    public interface ICategoryAdminService
    {
        Task<List<CategoryVM>> GetAllCategory(string languageId);
    }
}
