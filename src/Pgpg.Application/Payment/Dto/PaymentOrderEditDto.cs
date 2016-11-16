using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.Dto
{
    [AutoMap(typeof(PaymentOrder))]
    public class PaymentOrderEditDto
    {

    }
}
