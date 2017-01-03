using System.Threading.Tasks;

namespace Pgpg.Core.Smsing
{
    public interface ISmsSender
    {
        /// <summary>
        /// Sends an sms.
        /// 
        /// </summary>
        /// <param name="sms">Sms to be sent</param>
        void Send(SmsMessage sms);

        /// <summary>
        /// Sends an sms.
        /// 
        /// </summary>
        /// <param name="sms">Sms to be sent</param>
        Task SendAsync(SmsMessage sms);
    }
}