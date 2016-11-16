using System.Collections.Generic;
using Abp.Application.Services;

namespace Pgpg.Application.Payment
{
    public interface IPaymentService : IApplicationService
    {
        IList<IPaymentMethod> LoadActivePaymentMethods();

        IPaymentMethod LoadPaymentMethodBySystemName(string systemName);

    }
}
