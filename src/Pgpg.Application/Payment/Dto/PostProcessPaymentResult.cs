﻿using Pgpg.Core.Payment;

namespace Pgpg.Application.Payment.Dto
{
    public class PostProcessPaymentResult : IProcessResult
    {
        public PaymentStatus NewPaymentStatus { get; set; }

        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public string ReturnUrl { get; set; }

        public string OrderId { get; set; }

        public string OuterId { get; set; }
    }
}