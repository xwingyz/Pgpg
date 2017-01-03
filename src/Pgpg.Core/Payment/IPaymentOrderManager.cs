using System.Threading.Tasks;
using Abp.Domain.Services;

namespace Pgpg.Core.Payment
{
    public interface IPaymentOrderManager: IDomainService
    {
        Task CreatePaymentOrder(PaymentOrder paymentOrder);

        Task MarkPaymentOrderAsPaid(PaymentOrder paymentOrder);

        Task<bool> CanMarkOrderAsPaid(PaymentOrder paymentOrder);

        Task UpdatePaymentOrder(PaymentOrder paymentOrder);
    }
}