using MediatR;
using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Models.Response;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IAuthService _authService;

        public CreateUserHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}