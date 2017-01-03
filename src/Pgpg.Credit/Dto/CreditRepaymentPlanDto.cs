
using System;
using Abp.AutoMapper;
using Pgpg.Credit.Domain;

namespace Pgpg.Credit.Dto
{
    [AutoMapTo(typeof(CreditRepaymentPlan))]
    public class CreditRepaymentPlanDto
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
