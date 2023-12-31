using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.Domain.Entities;
using DiamondAuthServer.Domain.Entities.Authz;

namespace DiamondAuthServer.Persistence.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        public async Task<IEnumerable<Permission>> GetPermissionsAsync(UserDetail userDetail)
        {
            throw new NotImplementedException();
        }
    }
}