using DiamondAuthServer.Domain.Entities.Auth;

namespace DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories
{
    public interface IClientRepository
    {
        Task<Client> GetClientByIdAsync(string clientId);
    }
}