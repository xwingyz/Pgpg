using Microsoft.AspNetCore.Mvc;

namespace Pgpg.Web.Controllers
{
    public class AboutController : PgpgControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}