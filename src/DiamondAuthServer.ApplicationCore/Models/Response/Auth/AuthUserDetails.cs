using DiamondAuthServer.Domain.Entities;

namespace DiamondAuthServer.ApplicationCore.Models.Response.Auth
{
    public class AuthUserDetails : UserDetail
    {
        public bool IsAuthenticated { get; set; }
    }
}