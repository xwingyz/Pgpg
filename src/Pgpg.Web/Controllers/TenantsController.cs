using Abp.AspNetCore.Mvc.Authorization;
using Pgpg.Authorization;
using Pgpg.MultiTenancy;
using Microsoft.AspNetCore.Mvc;

namespace Pgpg.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : PgpgControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}