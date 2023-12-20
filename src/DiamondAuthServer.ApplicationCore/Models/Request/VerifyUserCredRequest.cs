using DiamondAuthServer.ApplicationCore.Commands;

namespace DiamondAuthServer.ApplicationCore.Models.Request
{
    public class VerifyUserCredRequest:ICommand<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}