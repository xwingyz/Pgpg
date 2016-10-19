using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pgpg.Authorization.Permissions.Dto;

namespace Pgpg.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
