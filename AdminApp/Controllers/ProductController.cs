using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShop.AdminApp.Services;
using MobileShop.Utilities.Constants;
using MobileShop.ViewModels.Catalog.Products;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductAdminService _productAdminService;
        private readonly ICategoryAdminService _categoryAdminService;
        public ProductController(IProductAdminService productAdminService, ICategoryAdminService categoryAdminService)
        {
            _productAdminService = productAdminService;
            _categoryAdminService = categoryAdminService;
        }
        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 5)
        {
            var languageId = HttpContext.Session.GetString(SystemConstans.AppSetting.DefaultLanguageId);
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId,
                CategoryId = categoryId
            };
            var data = await _productAdminService.GetPaging(request);
            ViewBag.Keyword = keyword;
            var categories = await _categoryAdminService.GetAllCategory(languageId);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var res = await _productAdminService.CreateProduct(request);
            if (res)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }
    }
}
