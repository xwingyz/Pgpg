using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Authorization;
using Pgpg.Web.Areas.Admin.Models.PhoneBusiness;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    public class CityController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new PhoneBusinessViewModel();
            return View(model);
        }
    }
}