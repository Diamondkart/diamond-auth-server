using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using DiamondAuthServer.Domain.Entities;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using System.Security.Claims;
using DiamondAuthServer.Domain.Constants;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IAccountService _accountService;
        private readonly IPermissionService _permissionService;
        

        public ProfileService(IAccountService accountService, IPermissionService permissionService)
        {
            _accountService = accountService;
            _permissionService = permissionService;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.GetSubjectId();
            var authUser = await _accountService.GetUserProfileAsync(new UserDetail { UserId = Guid.Parse(userId) });
            context.IssuedClaims.Add(new Claim(ClaimConstants.CLAIM_EMAIL, authUser.Email));
            context.IssuedClaims.Add(new Claim(ClaimConstants.CLAIM_FIRSTNAME, authUser.FirstName));
            context.IssuedClaims.Add(new Claim(ClaimConstants.CLAIM_MIDDLENAME, authUser.MiddleName));
            context.IssuedClaims.Add(new Claim(ClaimConstants.CLAIM_LASTNAME, authUser.LastName));
            await PopulateClaimsAsync(context);
        }
        private async Task PopulateClaimsAsync(ProfileDataRequestContext context)
        {
            var permissions = _permissionService.GetPermissionsAsync(new UserDetail { Email = "" });
            // add permissions to the claims
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}