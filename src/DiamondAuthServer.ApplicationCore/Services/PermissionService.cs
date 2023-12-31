using DiamondAuthServer.ApplicationCore.Ports.Out.IRepositories;
using DiamondAuthServer.ApplicationCore.Ports.Out.IServices;
using DiamondAuthServer.Domain.Entities;
using DiamondAuthServer.Domain.Entities.Authz;

namespace DiamondAuthServer.ApplicationCore.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository) 
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<IEnumerable<Permission>> GetPermissionsAsync(UserDetail userDetail)
        {
            return null;
        }
    }
}