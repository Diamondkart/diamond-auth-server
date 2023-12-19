using Evolve;
using System.Data;
using System.Data.Common;
using UserPlatform.Persistence.DbMigration.interfaces;

namespace UserPlatform.Persistence.DbMigration.migrations
{
    public class Migration : IMigration
    {
        public async Task<bool> RunMigration(IDbConnection connection, string migrationPath)
        {
            try
            {
                var evolve = new Evolve.Evolve((DbConnection)connection)
                {
                    Locations = new[] { migrationPath },
                    IsEraseDisabled = true,
                    CommandTimeout=300
                };
                evolve.Migrate();
                return true;
            }
            catch (Exception ex)
            {
                throw new EvolveException(migrationPath, ex);
            }
        }
    }
}