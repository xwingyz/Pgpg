using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pgpg.Application.Payment.Dto;
using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.WeChat
{
    public class WeChatPaymentMethod : PaymentMethod
    {
        public WeChatPaymentMethod(IPaymentOrderManager paymentOrderManager) : base(paymentOrderManager)
        {
        }
        public override ProcessPaymentResult ProcessPayment(ProcessPaymentInput context)
        {
            var result = new ProcessPaymentResult { NewPaymentStatus = PaymentStatus.Pending };
            return result;
        }

        public override PostProcessPaymentResult PostProcessPayment(PostProcessPaymentInput context)
        {
            bool isWeiXinBrowser = false;
            var order = context.Payment;

            throw new NotImplementedException();
        }

        public override RefundProcessPaymentResult Refund(RefundProcessPaymentInput context)
        {
            throw new NotImplementedException();
        }

        public override string PaymentChannel { get { return "微信支付"; } }
        public override string SystemName { get { return "WeChat"; } }
        public override bool SupportRefund { get { return true; } }
        public override bool SupportPartiallyRefund { get { return true; } }
        public override bool SupportCapture { get { return true; } }
        public override bool IsActive { get; set; }


    }
}
