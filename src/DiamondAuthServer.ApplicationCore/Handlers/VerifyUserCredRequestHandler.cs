using MediatR;
using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;

namespace UserPlatform.ApplicationCore.Handlers
{
    public class VerifyUserCredRequestHandler : IRequestHandler<VerifyUserCredRequest, bool>
    {
        private readonly IAuthService _authService;

        public VerifyUserCredRequestHandler(IAuthService authService) => _authService = _authService;

        public async Task<bool> Handle(VerifyUserCredRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}