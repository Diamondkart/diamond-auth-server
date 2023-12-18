using Microsoft.AspNetCore.Mvc;

namespace DiamondAuthServer.WebAPI.Controllers.v1
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
