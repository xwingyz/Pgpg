using Abp.AspNetCore.Mvc.Authorization;
using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Authorization;
using Pgpg.Web.Controllers;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : PgpgControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}