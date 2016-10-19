using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Configuration.Host.Dto;

namespace Pgpg.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
