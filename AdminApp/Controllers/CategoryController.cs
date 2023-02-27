using Microsoft.AspNetCore.Mvc;
using MobileShop.ApiIntergration.Interfaces;
using MobileShop.ViewModels.Catalog.Categories;
using System.Threading.Tasks;

namespace MobileShop.AdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiClient _categoryApiClient;
        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient= categoryApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _categoryApiClient.CreateCategory(request);
            if(result)
            {
                TempData["result"] = "Thêm danh mục thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm danh mục thất bại");
            return View(request);
        }
    }
}
