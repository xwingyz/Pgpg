using System.Threading.Tasks;
using Abp.Application.Navigation;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Configuration;
using Pgpg.Sessions;
using Pgpg.Web.Models.Layout;
using Pgpg.Web.Startup;

namespace Pgpg.Web.Views.Shared.Components.Header
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly IAbpSession _abpSession;
        private readonly ILanguageManager _languageManager;
        private readonly ISettingManager _settingManager;

        public HeaderViewComponent(
            ISessionAppService sessionAppService, 
            IUserNavigationManager userNavigationManager, 
            IMultiTenancyConfig multiTenancyConfig,
            IAbpSession abpSession,
            ILanguageManager languageManager, 
            ISettingManager settingManager)
        {
            _sessionAppService = sessionAppService;
            _userNavigationManager = userNavigationManager;
            _multiTenancyConfig = multiTenancyConfig;
            _abpSession = abpSession;
            _languageManager = languageManager;
            _settingManager = settingManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string currentPageName = "")
        {
            var headerModel = new HeaderViewModel();

            if (_abpSession.UserId.HasValue)
            {
                headerModel.LoginInformations = await _sessionAppService.GetCurrentLoginInformations();
            }

            headerModel.Languages = _languageManager.GetLanguages();
            headerModel.CurrentLanguage = _languageManager.CurrentLanguage;

            headerModel.Menu = await _userNavigationManager.GetMenuAsync(
                FrontEndNavigationProvider.MenuName,
                _abpSession.ToUserIdentifier()
            );

            headerModel.CurrentPageName = currentPageName;

            headerModel.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;
            headerModel.TenantRegistrationEnabled = await _settingManager.GetSettingValueAsync<bool>(AppSettings.TenantManagement.AllowSelfRegistration);

            return View(headerModel);
        }
    }
}
