namespace Pgpg.Core.Smsing
{
    public class SmsMessage
    {
        public string Phone { get; set; }
        public string MessageText { get; set; }

        public SmsMessage(string phone,string messageText)
        {
            Phone = phone;
            MessageText = messageText;
        }
    }
}