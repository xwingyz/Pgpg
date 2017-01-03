using Abp.Application.Services;
using Pgpg.Application.Tenants.Dashboard.Dto;

namespace Pgpg.Application.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
