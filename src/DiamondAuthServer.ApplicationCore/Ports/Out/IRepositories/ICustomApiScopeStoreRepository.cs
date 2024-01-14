using DiamondAuthServer.Domain.Entities.Auth;

namespace DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories
{
    public interface ICustomApiScopeStoreRepository
    {
        Task<IEnumerable<ClientScope>> GetApiScopesAsync();
    }
}