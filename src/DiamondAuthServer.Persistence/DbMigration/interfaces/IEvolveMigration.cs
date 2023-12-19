using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPlatform.Persistence.DbMigration.interfaces
{
    public interface IEvolveMigration
    {
        Task<bool> Migrate(IDbConnection connection, string connectionString);
        
    }
}
