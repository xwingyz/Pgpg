using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Application.Sessions;
using Pgpg.Web.Areas.Admin.Models.Layout;

namespace Pgpg.Web.Areas.Admin.Views.Shared.Components.AdminFooter
{
    public class AdminFooterViewComponent : ViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public AdminFooterViewComponent(
            ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };

            return View(footerModel);
        }
    }
}
