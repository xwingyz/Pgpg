using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Authorization;
using Pgpg.Web.Controllers;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : PgpgControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}