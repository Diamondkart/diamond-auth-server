using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using MediatR;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, bool>
    {
        private readonly IAuthService _authService;

        public ResetPasswordRequestHandler(IAuthService authService) => _authService = authService;

        public async Task<bool> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}