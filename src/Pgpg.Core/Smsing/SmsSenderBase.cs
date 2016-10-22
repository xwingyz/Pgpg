using System.Threading.Tasks;

namespace Pgpg.Smsing
{
    public abstract class SmsSenderBase : ISmsSender
    {
        public void Send(SmsMessage sms)
        {
            this.SendSms(sms);
        }

        public async Task SendAsync(SmsMessage sms)
        {
            await this.SendSmsAsync(sms);
        }

        protected abstract void SendSms(SmsMessage sms);
        

        protected abstract Task SendSmsAsync(SmsMessage sms);

    }
}