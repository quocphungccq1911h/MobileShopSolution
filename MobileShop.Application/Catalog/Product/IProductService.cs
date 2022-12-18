using MobileShop.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileShop.Application.Catalog.Product
{
    public interface IProductService
    {
        Task<List<ProductVm>> GetAll();
    }
}
