using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Pgpg.Core.Payment
{
    /// <summary>
    /// 支付订单
    /// </summary>
    [Table("PaymentOrder")]
    public class PaymentOrder : AuditedEntity<long>,  IMayHaveTenant
    {
        public long UserId { get; set; }

        public string PaymentChannel { get; set; }

        public string PaymentSystem { get; set; }

        public string OrderNo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public decimal OrderAmount { get; set; }

        public decimal Fee { get; set; }

        public decimal ActualAmount { get; set; }

        public decimal? RefundedAmount { get; set; }

        public DateTime? RefundTime { get; set; }

        public string Currency { get; set; }

        public DateTime? PaidTime { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string ThirdPartyOrderNo { get; set; }

        public string IpAddress { get; set; }

        public int? TenantId { get; set; }

    }
}
