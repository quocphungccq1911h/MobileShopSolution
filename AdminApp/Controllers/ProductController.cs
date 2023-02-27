using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileShop.ApiIntergration.Interfaces;
using MobileShop.Utilities.Constants;
using MobileShop.ViewModels.Catalog.Products;
using MobileShop.ViewModels.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
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
            var data = await _productApiClient.GetPaging(request);
            ViewBag.Keyword = keyword;
            var categories = await _categoryApiClient.GetAllCategory(languageId);
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
            var res = await _productApiClient.CreateProduct(request);
            if (res)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }
        [HttpGet]
        public async Task<IActionResult> AssignCategory(int id)
        {
            var categoryAssignRequest = await this.GetCategoryAssignRequest(id);
            return View(categoryAssignRequest);
        }
        [HttpPost]
        public async Task<IActionResult> AssignCategory(int id, CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _productApiClient.AssignCategory(request.Id, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật danh mục thất bại");
            var categoryAssignRequest = await this.GetCategoryAssignRequest(request.Id);
            return View(categoryAssignRequest);

        }
        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var language = HttpContext.Session.GetString(SystemConstans.AppSetting.DefaultLanguageId);
            var objProduct = await _productApiClient.GetProductById(id, language);
            var objCategory = await _categoryApiClient.GetAllCategory(language);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var item in objCategory)
            {
                categoryAssignRequest.Categories.Add(new SeletedItem()
                {
                    Id = item.Id.ToString(),
                    Name = item.Name,
                    Selected = objProduct.ResultObj.Categories.Contains(item.Name)
                });
            }
            return categoryAssignRequest;
        }
    }
}
