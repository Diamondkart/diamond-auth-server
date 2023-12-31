using DiamondAuthServer.Domain.Entities;
using DiamondAuthServer.Domain.Entities.Authz;

namespace DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetPermissionsAsync(UserDetail userDetail);
    }
}