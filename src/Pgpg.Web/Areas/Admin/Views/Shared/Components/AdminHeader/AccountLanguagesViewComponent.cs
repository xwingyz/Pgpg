using System.Threading.Tasks;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Application.Sessions;
using Pgpg.Web.Areas.Admin.Models.Layout;

namespace Pgpg.Web.Areas.Admin.Views.Shared.Components.AdminHeader
{
    public class AdminHeaderViewComponent : ViewComponent
    {
        private readonly ILanguageManager _languageManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly ISessionAppService _sessionAppService;
        private readonly IAbpSession _abpSession;

        public AdminHeaderViewComponent(
            IMultiTenancyConfig multiTenancyConfig, 
            ISessionAppService sessionAppService,
            IAbpSession abpSession, ILanguageManager languageManager)
        {
            _multiTenancyConfig = multiTenancyConfig;
            _sessionAppService = sessionAppService;
            _abpSession = abpSession;
            _languageManager = languageManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations(),
                Languages = _languageManager.GetLanguages(),
                CurrentLanguage = _languageManager.CurrentLanguage,
                IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled,
                IsImpersonatedLogin = _abpSession.ImpersonatorUserId.HasValue
            };

            return View(headerModel);
        }
    }
}
