using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pgpg.Application.Payment.Dto;
using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.Alipay
{
    public class AlipayPaymentMethod : PaymentMethod
    {

        public AlipayPaymentMethod(IPaymentOrderManager paymentOrderManager) : base(paymentOrderManager)
        {
        }
        

        public override PostProcessPaymentResult PostProcessPayment(PostProcessPaymentInput context)
        {
            throw new NotImplementedException();
        }

        public override RefundProcessPaymentResult Refund(RefundProcessPaymentInput context)
        {
            throw new NotImplementedException();
        }

        public override string PaymentChannel { get { return "支付宝"; } }
        public override string SystemName { get { return "Alipay"; } }
        public override bool SupportRefund { get { return true; } }
        public override bool SupportPartiallyRefund { get { return true; } }
        public override bool SupportCapture { get { return true; } }
        public override bool IsActive { get; set; }
    }
}
