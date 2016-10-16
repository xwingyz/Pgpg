using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pgpg.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PgpgControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}