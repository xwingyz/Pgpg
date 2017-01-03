using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Pgpg.Credit.Domain
{
    [Table("CreditRepaymentPlan")]
    public class CreditRepaymentPlan : Entity
    {
        /// <summary>
        /// 标的编号
        /// </summary>
        public long CreditId { get; set; }
        /// <summary>
        /// 期次
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// 收款日期
        /// </summary>
        [Column(TypeName = "date")]
        public DateTime RepaymentDate { get; set; }
        /// <summary>
        /// 应收本息
        /// </summary>
        public decimal PrincipalAndInterest { get; set; }
        /// <summary>
        /// 应收本金
        /// </summary>
        public decimal Principal { get; set; }
        /// <summary>
        /// 应收利息
        /// </summary>
        public decimal Interest { get; set; }
        /// <summary>
        /// 剩余本金
        /// </summary>
        public decimal RemainingPrincipal { get; set; }


    }
}
