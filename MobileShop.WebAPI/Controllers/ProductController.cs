using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Application.Catalog.Product;
using MobileShop.Application.System.Product;
using MobileShop.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace MobileShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IProductManageService _productManageService;
        public ProductController(IProductService service, IProductManageService productManageService)
        {
            _service = service;
            _productManageService = productManageService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll(string languageId)
        //{
        //    return Ok(await _service.GetAll(languageId));
        //}
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery]GetManageProductPagingRequest request)
        {
            var data = await _productManageService.GetAllPaging(request);
            return Ok(data);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]int productId, string languageId)
        {
            var product = await _productManageService.GetProductById(productId, languageId);
            if (product == null)
                return BadRequest();
            return Ok(product);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _productManageService.Create(request);
            if (res == 0)
            {
                return BadRequest();
            }
            var product = await _productManageService.GetProductById(res, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = res }, product);
        }
    }
}
