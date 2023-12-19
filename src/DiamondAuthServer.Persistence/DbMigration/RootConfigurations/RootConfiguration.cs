using DiamondAuthServer.Persistence.DbMigration.interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Persistence.DbMigration.RootConfigurations
{
    public class RootConfiguration : IRootConfiguration
    {
        public async Task<bool> ValidMigrationConfigurationPath(IConfiguration configuration)
        {
            var path = configuration.GetSection("RootConfiguration")["MigrationPath"];
            var directory = new DirectoryInfo(path);
            if (directory.Exists && directory.GetFiles().Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
