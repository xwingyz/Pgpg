using Abp.Domain.Services;

namespace Pgpg.Core
{
    public abstract class PgpgDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected PgpgDomainServiceBase()
        {
            LocalizationSourceName = PgpgConsts.LocalizationSourceName;
        }
    }
}
