namespace Pgpg.Application.Payment.Dto
{
    public class RefundProcessPaymentInput
    {
        public PaymentOrderEditDto Payment { get; set; }

        public decimal AmountToRefund { get; set; }
       
        public bool IsPartialRefund { get; set; }
    }
}