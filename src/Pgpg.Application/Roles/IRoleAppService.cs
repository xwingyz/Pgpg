using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Roles.Dto;

namespace Pgpg.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
