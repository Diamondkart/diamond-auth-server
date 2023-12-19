using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Persistence.DbMigration.interfaces
{
    public interface IRootConfiguration
    {
        Task<bool> ValidMigrationConfigurationPath(IConfiguration configuration);
    }
}
