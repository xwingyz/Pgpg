using System;
using System.Collections.Generic;
using Abp.Dependency;
using Pgpg.Credit.Dto;

namespace Pgpg.Credit.Service
{
    public interface ICalculatorService : ITransientDependency
    {
        /// <summary>
        /// 复利计算
        /// </summary>
        /// <param name="starDate">开始投资日期</param>
        /// <param name="endDate">结束投资日期</param>
        /// <param name="amount">投资金额</param>
        /// <param name="rate">年利率</param>
        /// <returns></returns>
        decimal CalculationCompoundInterest(DateTime starDate, DateTime endDate, decimal amount, decimal rate);
        /// <summary>
        /// 计算收益
        /// </summary>
        /// <param name="repaymentWay">还款方式</param>
        /// <param name="starDate">开始投资日期</param>
        /// <param name="endDate">结束投资日期</param>
        /// <param name="amount">投资金额</param>
        /// <param name="rate">年利率</param>
        /// <returns>还款计划</returns>
        List<CreditRepaymentPlanDto> CalculationIncome(RepaymentWay repaymentWay, DateTime starDate, DateTime endDate,
            decimal amount, decimal rate);

    }
}