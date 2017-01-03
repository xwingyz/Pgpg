namespace Pgpg.Application.Payment.Dto
{
    public class ProcessPaymentInput
    {
        public int? TenantId { get; set; }
        public long UserId { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string PaymentChannel { get; set; }

        public string PaymentSystemName { get; set; }

        public string OrderNo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string IpAddress { get; set; }

    }
}