using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiamondAuthServer.WebAPI.Controllers.v1
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ClientsController : ControllerBase
    {
        [HttpGet]
        [Route("Secrets/Encrypt/{clientSecret}")]
        public async Task<IActionResult> EncryptClientSecret(string clientSecret)
        {
            return Ok(clientSecret.Sha256());
        }
    }
}
