using System;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Dependency;
using Castle.Core.Logging;
using Pgpg.Application.Submall.Lib;
using Pgpg.Core.Smsing;
using Pgpg.Core.Validation;

namespace Pgpg.Application.Submall
{
    public class SubmallSmsMessageService : SmsSenderBase, ITransientDependency
    {
        private readonly ISettingManager _settingManager;
        public ILogger Logger { get; set; }

        public SubmallSmsMessageService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
            Logger = NullLogger.Instance;
        }

        protected bool SendSms(string phone, string message)
        {
            if (!new ValidationHelper().IsPhoneNumber(phone))
            {
                throw new Exception("Invalid cell phone number.");
            }
            var appid = _settingManager.GetSettingValue(SubmallSettingNames.AppId);
            var appKey = _settingManager.GetSettingValue(SubmallSettingNames.AppKey);
            var title = _settingManager.GetSettingValue(SubmallSettingNames.Title);
            IAppConfig config = new MessageConfig(appid, appKey, SignType.md5);
            MessageSend ms = new MessageSend(config);
            ms.AddTo(phone);
            ms.AddContent($"【{title}】{message}");
            string returnMessage = "";
            bool rs = ms.Send(out returnMessage);
            if (!rs && !string.IsNullOrEmpty(returnMessage))
            {
                Logger.Error(returnMessage + "--" + message);
            }
            return rs;
        }

        protected override void SendSms(SmsMessage sms)
        {
            SendSms(sms.Phone, sms.MessageText);
        }

        protected override Task SendSmsAsync(SmsMessage sms)
        {
            return Task.Run(() => { Send(sms); });
        }
    }
}