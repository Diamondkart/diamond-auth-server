using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class AuthConfig
    {
        private readonly ICustomApiScopeStoreRepository _customApiScopeStoreRepository;

        public AuthConfig(ICustomApiScopeStoreRepository customApiScopeStoreRepository)
        {
            _customApiScopeStoreRepository = customApiScopeStoreRepository;
        }

        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            new ApiScope(IdentityServerConstants.StandardScopes.OpenId, "Description of User Profile"),
            new ApiScope(IdentityServerConstants.StandardScopes.Profile, "Description of User Profile"),
            new ApiScope("provisionz", "Description of User provision"),
        };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("UserPlatform", "UserPlatform Resource")
                {
                    Scopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                }
            };
    }
}