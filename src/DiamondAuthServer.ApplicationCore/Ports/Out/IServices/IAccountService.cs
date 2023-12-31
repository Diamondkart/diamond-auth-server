using DiamondAuthServer.ApplicationCore.Models.Response.Auth;
using DiamondAuthServer.Domain.Entities;

namespace DiamondAuthServer.ApplicationCore.Ports.Out.IServices
{
    public interface IAccountService
    {
        Task<AuthUserDetails> VerifyUserCredentialAsync(UserDetail userDetail);
        Task<AuthUserDetails> GetUserProfileAsync(UserDetail userDetail);
    }
}