using Microsoft.Extensions.Configuration;
using System.Data;

namespace UserPlatform.Persistence.DbMigration.interfaces
{
    public interface IMigration
    {
        Task<bool> RunMigration(IDbConnection connection, string migrationPath);
    }
}