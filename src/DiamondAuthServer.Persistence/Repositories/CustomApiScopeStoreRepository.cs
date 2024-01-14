using Dapper;
using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.Domain.Entities.Auth;
using DiamondAuthServer.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.Persistence.Repositories
{
    public class CustomApiScopeStoreRepository : ICustomApiScopeStoreRepository
    {
        private readonly ISQLDatabase _database;

        public CustomApiScopeStoreRepository(ISQLDatabase database)
        {
            _database = database;
        }
        public async Task<IEnumerable<ClientScope>> GetApiScopesAsync()
        {
            var query = "SELECT ID, Name from auth.ClientScope";
            using (var context=_database.GetConnection())
            {
                var queryResult = await context.QueryAsync<ClientScope>(query, commandType: CommandType.Text);
                return queryResult;
            }
        }
    }
}
