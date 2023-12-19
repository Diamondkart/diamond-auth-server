using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Persistence.Repositories.Interfaces
{
    public interface ISQLDatabase
    {
        IDbConnection GetConnection();
    }
}
