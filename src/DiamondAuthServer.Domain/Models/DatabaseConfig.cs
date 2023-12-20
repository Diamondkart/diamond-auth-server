using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Domain.Models
{
    public class DatabaseConfig
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public int CommandTimeOut { get; set; }
        public bool Encrypt { get; set; }
    }
}
