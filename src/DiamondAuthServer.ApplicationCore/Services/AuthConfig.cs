using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class AuthConfig
    {
        public AuthConfig()
        {
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
                    
                }
            };

        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "auth-ropc-9c6db90a-8925-486b-bf99-c6ede057ad38",
                ClientName = "Auth",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = new List<string>{GrantType.ResourceOwnerPassword},
                RequirePkce = false,
                RequireClientSecret = true,
                RedirectUris = {},
                PostLogoutRedirectUris = {},
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                }
            },
            new Client
            {
                ClientId = "cc-9c6db90a-8925-486b-bf99-c6ede057ad38",
                ClientName = "Client.m2m",
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                RequirePkce = false,
                RequireClientSecret = true,
                RedirectUris = {},
                PostLogoutRedirectUris = {},
                //AlwaysIncludeUserClaimsInIdToken = true,
                //AllowOfflineAccess = true,
                AllowedScopes =
                {
                    "provision",
                    
                }
            }
        };
    }
}