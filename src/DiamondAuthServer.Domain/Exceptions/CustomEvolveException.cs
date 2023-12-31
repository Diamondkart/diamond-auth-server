using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Domain.Exceptions
{
    public class CustomEvolveException: Exception
    {
        public CustomEvolveException()
        {
        }

        public CustomEvolveException(string message)
            : base(message)
        {
        }

        public CustomEvolveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
