using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Configuration.Tenants.Dto;

namespace Pgpg.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);
    }
}
