using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Models.Response;
using DiamondAuthServer.Domain.Entities;

namespace DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories
{
    public interface IAccountRespository
    {
        Task<ChangePassword> RequestChangePasswordAsync(ChangePassword changePassword);

        Task<bool> GeneratePasswordAsync(UserDetail userDetails);

        Task<ChangePassword> GetChangePasswordByTokenPasswordAsync(ChangePassword changePassword);

        Task<bool> UpdatePasswordAndPasswordTokenValidityAsync(UserDetail user, ChangePassword changePassword);
        Task<UserDetail> CreateAccountAsync(UserDetail userDetail);
        Task<bool> CheckIfUserIsUnique(UserDetail userDetails);
    }
}