using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Application.Configuration.Tenants.Dto;

namespace Pgpg.Application.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);
    }
}
