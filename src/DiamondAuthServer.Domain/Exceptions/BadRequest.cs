using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Domain.Exceptions
{
    public class BadRequest: Exception
    {
        public BadRequest()
        {
        }

        public BadRequest(string message)
            : base(message)
        {
        }

        public BadRequest(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
