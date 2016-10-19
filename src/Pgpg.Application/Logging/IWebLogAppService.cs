using Abp.Application.Services;
using Pgpg.Dto;
using Pgpg.Logging.Dto;

namespace Pgpg.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
