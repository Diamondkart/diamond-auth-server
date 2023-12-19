using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Domain.Exceptions
{
    public class EvolveException: Exception
    {
        public EvolveException()
        {
        }

        public EvolveException(string message)
            : base(message)
        {
        }

        public EvolveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
