using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.Dto
{
    public class ProcessPaymentResult : IProcessResult
    {
        public string ErrorMessage { get; set; }
        public PaymentStatus NewPaymentStatus { get; set; }

        public string RedirectUrl { get; set; }

        public string HtmlForm { get; set; }

        public bool IsSuccess { get; set; }

        public string OuterId { get; set; }
    }
}