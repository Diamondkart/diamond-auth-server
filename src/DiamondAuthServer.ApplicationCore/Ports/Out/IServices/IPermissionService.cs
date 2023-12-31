using DiamondAuthServer.Domain.Entities.Authz;
using DiamondAuthServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondAuthServer.ApplicationCore.Ports.Out.IServices
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permission>> GetPermissionsAsync(UserDetail userDetail);
    }
}
