using Microsoft.AspNetCore.Mvc;
using MobileShop.Application.Catalog.Categories;
using MobileShop.ViewModels.Catalog.Categories;
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _categoryService.Create(request);
            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
