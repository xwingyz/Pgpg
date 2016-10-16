using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNet.Identity;
using Abp.IdentityFramework;

namespace Pgpg.Web.Controllers
{
    public abstract class PgpgControllerBase: AbpController
    {
        protected PgpgControllerBase()
        {
            LocalizationSourceName = PgpgConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}