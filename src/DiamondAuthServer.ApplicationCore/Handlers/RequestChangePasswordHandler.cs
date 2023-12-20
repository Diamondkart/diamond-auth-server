using MediatR;
using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Models.Response;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class RequestChangePasswordHandler : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
    {
        private readonly IAuthService _authService;

        public RequestChangePasswordHandler(IAuthService authService) => _authService = authService;

        public async Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}