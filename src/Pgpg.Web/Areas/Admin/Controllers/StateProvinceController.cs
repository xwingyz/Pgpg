using Microsoft.AspNetCore.Mvc;
using Pgpg.Web.Areas.Admin.Models.PhoneBusiness;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    public class StateProvinceController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new PhoneBusinessViewModel();
            return View(model);
        }
    }
}