using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.Dto
{
    public class RefundProcessPaymentResult : IProcessResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public PaymentStatus NewPaymentStatus { get; set; }
    }
}