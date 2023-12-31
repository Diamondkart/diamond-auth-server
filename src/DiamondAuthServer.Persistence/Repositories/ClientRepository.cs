using Dapper;
using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.Domain.Entities.Auth;
using DiamondAuthServer.Domain.Entities.SP;
using DiamondAuthServer.Persistence.Repositories.Interfaces;
using System.Data;

namespace DiamondAuthServer.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISQLDatabase _database;

        public ClientRepository(ISQLDatabase database)
        {
            _database = database;
        }

        public async Task<Client> GetClientByIdAsync(string clientId)
        {
            var clientMap = new Dictionary<string, Client>();
            using (var context = _database.GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("clientId", clientId);
                var result = await context.QueryAsync<Client, ClientGrantType, ClientScope, Client>(
                    SP.SP_GetClients,
                    (cl, gt, sc) => 
                    {
                        if (!clientMap.ContainsKey(cl.ClientId))
                        {
                            cl.GrantTypes = new List<ClientGrantType> { new ClientGrantType { GrantType=gt.GrantType } };
                            cl.Scopes = new List<ClientScope> { new ClientScope { Scope = sc.Scope } };
                            clientMap.Add(cl.ClientId, cl);
                        }
                        else
                        {
                            clientMap[cl.ClientId].GrantTypes.Add(new ClientGrantType { GrantType = gt.GrantType });
                            clientMap[cl.ClientId].Scopes.Add(new ClientScope { Scope = sc.Scope });
                            clientMap[cl.ClientId].GrantTypes = clientMap[cl.ClientId].GrantTypes.DistinctBy(x => x.GrantType).ToList();
                            clientMap[cl.ClientId].Scopes = clientMap[cl.ClientId].Scopes.DistinctBy(x => x.Scope).ToList();
                        }
                        
                        return cl;
                        
                    },
                    parameters, 
                    commandType: CommandType.StoredProcedure,
                    splitOn: "GrantType,Scope");

                return clientMap.Values.FirstOrDefault();
            }
        }
    }
}