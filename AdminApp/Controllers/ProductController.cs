using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.AdminApp.Services;
using MobileShop.Utilities.Constants;
using MobileShop.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductAdminService _productAdminService;
        public ProductController(IProductAdminService productAdminService)
        {
            _productAdminService = productAdminService;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var languageId = HttpContext.Session.GetString(SystemConstans.AppSetting.DefaultLanguageId);
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            };
            var data = await _productAdminService.GetPaging(request);
            if(TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
    }
}
