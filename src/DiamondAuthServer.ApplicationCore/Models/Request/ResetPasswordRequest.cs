using DiamondAuthServer.ApplicationCore.Commands;
using static DiamondAuthServer.ApplicationCore.Utils.Utils;

namespace DiamondAuthServer.ApplicationCore.Models.Request
{
    public class ResetPasswordRequest : ICommand<bool>
    {
        public string? Token { get; set; }
        public string TempPassword { get; set; }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                var hashedPassword = GetSecurePassword(value);
                _password = hashedPassword.Password;
                Salt = hashedPassword.Salt;
            }
        }

        public string? Salt { get; set; }
        private string _password;
    }
}