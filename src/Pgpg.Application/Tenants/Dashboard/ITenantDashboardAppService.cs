using Abp.Application.Services;
using Pgpg.Tenants.Dashboard.Dto;

namespace Pgpg.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
