using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class TokenService : ITokenService
    {
        public Task<Token> CreateAccessTokenAsync(TokenCreationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Token> CreateIdentityTokenAsync(TokenCreationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateSecurityTokenAsync(Token token)
        {
            throw new NotImplementedException();
        }
    }
}