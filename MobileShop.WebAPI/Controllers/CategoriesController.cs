using Microsoft.AspNetCore.Mvc;
using MobileShop.Application.Catalog.Categories;
using System.Threading.Tasks;

namespace MobileShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory(string languageId)
        {
            var data = await _categoryService.GetAll(languageId);
            return Ok(data);
        }
    }
}
