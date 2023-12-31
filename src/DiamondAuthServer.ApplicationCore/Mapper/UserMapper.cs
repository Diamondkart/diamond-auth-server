using AutoMapper;
using DiamondAuthServer.ApplicationCore.Models.Request;
using DiamondAuthServer.ApplicationCore.Models.Response;
using DiamondAuthServer.ApplicationCore.Models.Response.Auth;
using DiamondAuthServer.Domain.Entities;

namespace UserPlatform.ApplicationCore.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            

            CreateMap<ChangePassword, ChangePasswordResponse>();
            CreateMap<ResetPasswordRequest, UserDetail>();
            CreateMap<ResetPasswordRequest, ChangePassword>();
            CreateMap<VerifyUserCredRequest, UserDetail>();
            CreateMap<UserDetail, AuthUserDetails>();
        }
    }
}