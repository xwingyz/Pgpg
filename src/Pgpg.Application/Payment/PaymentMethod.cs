using Pgpg.Application.Payment.Dto;
using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment
{
    /// <summary>
    /// 代表一个支付渠道插件
    /// </summary>
    public abstract class PaymentMethod : IPaymentMethod
    {
        protected readonly IPaymentOrderManager _paymentOrderManager;
        public PaymentMethod(IPaymentOrderManager paymentOrderManager)
        {
            _paymentOrderManager = paymentOrderManager;
        }

        public virtual ProcessPaymentResult ProcessPayment(ProcessPaymentInput context)
        {
            _paymentOrderManager.CreatePaymentOrder(new PaymentOrder()
            {
                UserId = context.UserId,
                PaymentChannel = this.PaymentChannel,
                OrderAmount = context.Amount,
                ActualAmount = context.Amount,
                Currency = context.Currency,
                Fee = GetFee(context.Amount),
                OrderNo = context.OrderNo,
                PaymentStatus = PaymentStatus.New,
                PaymentSystem = SystemName,
                IpAddress = context.IpAddress,
                Subject = context.Subject,
                Body = context.Body,
                TenantId = context.TenantId,
            });
            var result = new ProcessPaymentResult { NewPaymentStatus = PaymentStatus.New };
            return result;
        }


        protected virtual decimal GetFee(decimal amount)
        {
            return amount * 0.006m;
        }

        public abstract PostProcessPaymentResult PostProcessPayment(PostProcessPaymentInput context);

        public abstract RefundProcessPaymentResult Refund(RefundProcessPaymentInput context);

        public abstract string PaymentChannel { get; }

        public abstract string SystemName { get; }

        public abstract bool SupportRefund { get; }

        public abstract bool SupportPartiallyRefund { get; }

        public abstract bool SupportCapture { get; }

        public abstract bool IsActive { get; set; }
    }
}