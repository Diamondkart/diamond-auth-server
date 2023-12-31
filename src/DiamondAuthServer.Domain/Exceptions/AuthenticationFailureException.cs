using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Domain.Exceptions
{
    public class AuthenticationFailureException : Exception
    {
        public AuthenticationFailureException()
        {
        }

        public AuthenticationFailureException(string message)
            : base(message)
        {
        }

        public AuthenticationFailureException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
