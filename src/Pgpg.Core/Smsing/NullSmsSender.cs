using System.Threading.Tasks;
using Castle.Core.Logging;

namespace Pgpg.Smsing
{
    public class NullSmsSender : SmsSenderBase
    {
        public ILogger Logger { get; set; }

        public NullSmsSender()
        {
            Logger = NullLogger.Instance;
        }

        protected override void SendSms(SmsMessage sms)
        {
            this.Logger.Warn("USING NullSmsSender!");
            this.Logger.Debug("SendSms:");
            LogEmail(sms);
        }

        protected override Task SendSmsAsync(SmsMessage sms)
        {
            this.Logger.Warn("USING NullSmsSender!");
            this.Logger.Debug("SendSmsAsync:");
            LogEmail(sms);
            return Task.FromResult(0);
        }

        private void LogEmail(SmsMessage sms)
        {
            this.Logger.Debug(sms.Phone.ToString());
            this.Logger.Debug(sms.MessageText.ToString());
        }
    }
}