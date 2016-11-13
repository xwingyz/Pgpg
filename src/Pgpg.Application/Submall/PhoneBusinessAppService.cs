using Abp.Configuration;
using Pgpg.Application.Submall.Lib;

namespace Pgpg.Application.Submall
{
    public class PhoneBusinessAppService : PgpgAppServiceBase, IPhoneBusinessAppService
    {
        private readonly ISettingManager _settingManager;
        public PhoneBusinessAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public bool Charge(string phoneNumber, string packageType)
        {
            var appid = _settingManager.GetSettingValue(SubmallSettingNames.MobileTrafficPackageAppId);
            IAppConfig config = new MessageConfig(appid, "", SignType.md5);
            return new Mobiledata(config).Charge(phoneNumber, packageType);
        }

    }
}