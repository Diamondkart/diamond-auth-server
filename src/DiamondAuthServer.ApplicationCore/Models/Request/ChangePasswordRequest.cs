using DiamondAuthServer.ApplicationCore.Commands;
using DiamondAuthServer.ApplicationCore.Models.Response;

namespace DiamondAuthServer.ApplicationCore.Models.Request
{
    public class ChangePasswordRequest : ICommand<ChangePasswordResponse>
    {
        public string UserIdentifier { get; set; }
    }
}

/*
 * PasswordChangeId, UserId, TempPassword, ExpireOn, Token
 * 
 * 
 */