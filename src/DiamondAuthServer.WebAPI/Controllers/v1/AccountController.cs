using DiamondAuthServer.ApplicationCore.Commands;
using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DiamondAuthServer.WebAPI.Controllers.v1
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public AccountController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
    }
}