using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Domain.Entities.Auth
{
    public class ClientScope
    {
        public Guid ID { get; set; }
        public string Scope { get; set; }
        
    }
}
