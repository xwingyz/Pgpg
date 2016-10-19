using Microsoft.AspNetCore.Mvc;

namespace Pgpg.Web.Controllers
{
    public class HomeController : PgpgControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}