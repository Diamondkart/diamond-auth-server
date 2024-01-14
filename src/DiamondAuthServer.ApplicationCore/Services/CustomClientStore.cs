using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class CustomClientStore : IClientStore
    {
        private readonly IAuthService _authService;
        private readonly IClientRepository _clientRepository;

        public CustomClientStore(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client?> FindClientByIdAsync(string clientId)
        {
            var clientEntity = await _clientRepository.GetClientByIdAsync(clientId);
            if (clientEntity != null)
            {
                // Map the clientEntity to a Client object
                var client = new Client
                {
                    ClientId = clientEntity.ClientId,
                    ClientName = clientEntity.Name,
                    ClientSecrets = { new Secret(clientEntity.ClientSecret) },
                    AllowedGrantTypes = clientEntity.GrantTypes.Select(s => s.GrantType).ToList(),
                    RequirePkce = false,
                    RequireClientSecret = true,
                    RedirectUris = { },
                    PostLogoutRedirectUris = { },
                    AlwaysIncludeUserClaimsInIdToken = clientEntity.AlwaysIncludeUserClaimsInIdToken,
                    AllowOfflineAccess = true,
                    AllowedScopes = clientEntity.Scopes.Select(s => s.Scope).ToList(),
                };

                return client;
            }
            return null;
        }
    }
}