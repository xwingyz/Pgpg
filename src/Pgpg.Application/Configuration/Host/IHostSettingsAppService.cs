using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Application.Configuration.Host.Dto;

namespace Pgpg.Application.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);

        Task SendTestSms(SendTestSmsInput input);
    }
}
