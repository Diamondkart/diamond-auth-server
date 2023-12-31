using AutoMapper;
using DiamondAuthServer.ApplicationCore.Models.Response.Auth;
using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using DiamondAuthServer.Domain.Entities;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRespository _accountRespository;

        public AccountService(IMapper mapper, IAccountRespository accountRespository)
        {
            _mapper = mapper;
            _accountRespository = accountRespository;
        }

        public async Task<AuthUserDetails> VerifyUserCredentialAsync(UserDetail userDetail)
        {
            var user = await _accountRespository.GetUserByEmailAsync(userDetail.Email);
            if (user == null)
            {
                //throw new AuthenticationFailureException(AuthConstants.InvalidUserOrPassword);
                return new AuthUserDetails { IsAuthenticated = false };
            }
            var inputHashPassword = Utils.Utils.GetSecurePassword(userDetail.Password, user.Salt);
            if (!inputHashPassword.Password.Equals(user.Password))
            {
                //throw new AuthenticationFailureException(AuthConstants.InvalidUserOrPassword);
                return new AuthUserDetails { IsAuthenticated = false };
            }
            if (userDetail.Email.Equals(user.Email) && inputHashPassword.Password.Equals(user.Password))
            {
                var authUserDetails=_mapper.Map<AuthUserDetails>(user);
                authUserDetails.IsAuthenticated = true;
                return authUserDetails;
            }
            return new AuthUserDetails { IsAuthenticated = false };
        }
        public async Task<AuthUserDetails> GetUserProfileAsync(UserDetail userDetail)
        {
            var user=await _accountRespository.GetUserByIdAsync(userDetail.UserId);
            var authUser = _mapper.Map<AuthUserDetails>(user);
            return authUser;
        }
    }
}