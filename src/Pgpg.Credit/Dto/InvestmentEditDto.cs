using Abp.AutoMapper;
using Abp.Domain.Entities;
using Pgpg.Credit.Domain;

namespace Pgpg.Credit.Dto
{
    [AutoMapTo(typeof(Investment))]
    public class InvestmentEditDto : IPassivable
    {
        public long? Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 标的Id
        /// </summary>
        public long CreditId { get; set; }
        /// <summary>
        /// 投资金额
        /// </summary>
        public decimal TransAmount { get; set; }
        /// <summary>
        /// 年利率
        /// </summary>
        public decimal AnnualInterestRate { get; set; }

        public decimal BidFeeRate { get; set; }
        public bool IsActive { get; set; }
    }
}