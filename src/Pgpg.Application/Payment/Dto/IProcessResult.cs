using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.Dto
{
    public interface IProcessResult
    {
        bool IsSuccess { get; set; }
        string ErrorMessage { get; set; }
        PaymentStatus NewPaymentStatus { get; set; }
    }
}