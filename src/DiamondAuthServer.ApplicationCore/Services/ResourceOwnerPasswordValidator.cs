using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using DiamondAuthServer.Domain.Entities;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.ResponseHandling;
using Duende.IdentityServer.Validation;
using IdentityModel;
using System.Net;
using System.Security.Claims;
using static IdentityModel.OidcConstants;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IAccountService _accountService;

        public ResourceOwnerPasswordValidator(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var userDetails = new UserDetail { Email = context.UserName, Password = context.Password };
            var authUserDetails = await _accountService.VerifyUserCredentialAsync(userDetails);
            if (!authUserDetails.IsAuthenticated)
            {
                // Invalid user or password
                context.Result = new GrantValidationResult(TokenRequestErrors.UnauthorizedClient, "Invalid user credentials");
                return;
            }
            // User and password are valid
            context.Result = new GrantValidationResult(
                subject: authUserDetails.UserId.ToString(),
                authenticationMethod: OidcConstants.AuthenticationMethods.Password
            );
        }
    }
}