using DiamondAuthServer.ApplicationCore.Commands;
using DiamondAuthServer.ApplicationCore.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DiamondAuthServer.WebAPI.Controllers.v1
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public AuthController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) 
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        [HttpPost]
        [Route("RequestPassChange", Name = "RequestPasswordChange")]
        public async Task<IActionResult> RequestPasswordChange()
        {
            return Ok();
        }
        [HttpPost]
        [Route("ResetPassword", Name = "ResetPassword")]
        public async Task<IActionResult> ResetPassword()
        {
            return Ok();
        }
    }
}
