using Abp.Dependency;
using Pgpg.Application.Payment.Dto;

namespace Pgpg.Application.Payment
{
    public interface IPaymentMethod : ITransientDependency
    {
        bool IsActive { get; set; }
        string PaymentChannel { get; }
        bool SupportCapture { get; }
        bool SupportPartiallyRefund { get; }
        bool SupportRefund { get; }
        string SystemName { get; }

        PostProcessPaymentResult PostProcessPayment(PostProcessPaymentInput context);
        ProcessPaymentResult ProcessPayment(ProcessPaymentInput context);
        RefundProcessPaymentResult Refund(RefundProcessPaymentInput context);
    }
}