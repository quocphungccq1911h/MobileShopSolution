using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Application.System.Users;
using MobileShop.ViewModels.System.Users;
using System.Threading.Tasks;

namespace MobileShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultToken = await _service.Authencate(request);
            if(string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("UserName or password is incorrect.");
            }
            return Ok(resultToken);
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.Register(request);
            if(!result)
            {
                return BadRequest("Register is unsuccessful.");
            }
            return Ok();
        }
    }
}
