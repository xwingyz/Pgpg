using System.Collections.Generic;
using System.Linq;
using Abp.Dependency;
using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment
{
    public class PaymentService :PgpgAppServiceBase, IPaymentService
    {
        private readonly IPaymentOrderManager _paymentOrderManager;

        public PaymentService(IPaymentOrderManager paymentOrderManager)
        {
            _paymentOrderManager = paymentOrderManager;
        }

        public IList<IPaymentMethod> LoadActivePaymentMethods()
        {
            return IocManager.Instance.ResolveAll<IPaymentMethod>();
        }

        public IPaymentMethod LoadPaymentMethodBySystemName(string systemName)
        {
            return IocManager.Instance.ResolveAll<IPaymentMethod>().SingleOrDefault(pm => pm.SystemName == systemName);
        }
    }
}