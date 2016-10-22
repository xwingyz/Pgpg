using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Web.Areas.Admin.Models.PhoneBusiness;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    public class PhoneBusinessController : AdminControllerBase
    {
        public ActionResult Index()
        {
            var model = new PhoneBusinessViewModel();
            return View(model);
        }
    }
}
