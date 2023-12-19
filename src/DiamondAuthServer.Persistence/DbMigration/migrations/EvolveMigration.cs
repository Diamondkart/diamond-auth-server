using System.Data;
using UserPlatform.Persistence.DbMigration.interfaces;

namespace UserPlatform.Persistence.DbMigration.migrations
{
    public class EvolveMigration : IEvolveMigration
    {
        public Task<bool> Migrate(IDbConnection connection, string connectionString)
        {
            throw new NotImplementedException();
        }
    }
}