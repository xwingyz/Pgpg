using System.Threading.Tasks;
using Abp.Application.Services;
using Pgpg.Application.Sessions.Dto;

namespace Pgpg.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
