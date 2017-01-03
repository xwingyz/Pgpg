using Abp.Application.Services;
using Pgpg.Application.Dto;
using Pgpg.Application.Logging.Dto;

namespace Pgpg.Application.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
