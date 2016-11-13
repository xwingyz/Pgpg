using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pgpg.Application.Authorization.Permissions.Dto;

namespace Pgpg.Application.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
