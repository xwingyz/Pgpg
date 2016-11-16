using System.Collections.Specialized;

namespace Pgpg.Application.Payment.Dto
{
    public class PostProcessPaymentInput
    {
        public PostProcessPaymentInput()
        {

        }

        public PostProcessPaymentInput(PaymentOrderEditDto payment)
        {
            this.Payment = payment;
        }

        public PaymentOrderEditDto Payment { get; set; }

        public NameValueCollection Parameters { get; set; }
    }
}