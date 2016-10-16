using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Sessions.Dto;

namespace Pgpg.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
