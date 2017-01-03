using System.Collections.Generic;
using Abp.RealTime;

namespace Pgpg.Core.Authorization.Users
{
    public interface IUserLogoutInformer
    {
        void InformClients(IReadOnlyList<IOnlineClient> clients);
    }
}
