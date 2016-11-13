using Abp;

namespace Pgpg.Core
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="PgpgDomainServiceBase"/>.
    /// For application services inherit PgpgAppServiceBase.
    /// </summary>
    public abstract class PgpgServiceBase : AbpServiceBase
    {
        protected PgpgServiceBase()
        {
            LocalizationSourceName = PgpgConsts.LocalizationSourceName;
        }
    }
}