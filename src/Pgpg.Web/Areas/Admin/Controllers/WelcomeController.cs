using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Web.Controllers;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AbpMvcAuthorize]
    public class WelcomeController : PgpgControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}