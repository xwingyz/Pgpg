using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Timing;

namespace Pgpg.Core.Payment
{
    public class PaymentOrderManager : PgpgDomainServiceBase, IPaymentOrderManager
    {
        //private readonly IRepository<PaymentOrder, long> _paymentOrderRepository;

        //public PaymentOrderManager(IRepository<PaymentOrder, long> paymentOrderRepository)
        //{
        //    _paymentOrderRepository = paymentOrderRepository;
        //}

        //public async Task CreatePaymentOrder(PaymentOrder paymentOrder)
        //{
        //    await _paymentOrderRepository.InsertAsync(paymentOrder);
        //}

        //public async Task MarkPaymentOrderAsPaid(PaymentOrder paymentOrder)
        //{
        //    paymentOrder.PaymentStatus = PaymentStatus.Paid;
        //    paymentOrder.PaidTime = Clock.Now;
        //    await _paymentOrderRepository.UpdateAsync(paymentOrder);
        //}

        public Task CreatePaymentOrder(PaymentOrder paymentOrder)
        {
            throw new System.NotImplementedException();
        }

        public Task MarkPaymentOrderAsPaid(PaymentOrder paymentOrder)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CanMarkOrderAsPaid(PaymentOrder paymentOrder)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdatePaymentOrder(PaymentOrder paymentOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}