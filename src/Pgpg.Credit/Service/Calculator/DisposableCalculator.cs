using System;
using System.Collections.Generic;
using Pgpg.Credit.Dto;
using Pgpg.Credit.Utility;

namespace Pgpg.Credit.Service
{
    public class DisposableCalculator : CalculatorBase
    {
        public override List<CreditRepaymentPlanDto> CalculationIncome(DateTime startDate, DateTime endDate, decimal transAmount, decimal rate)
        {
            var list = new List<CreditRepaymentPlanDto>();
            var 天利率 = rate / 360;
            var 借款天数 = (endDate - startDate).Days;
            var 利息 = 按天计算利息(transAmount, 天利率, 借款天数).ToFixed(2);
            var temppPlan = new CreditRepaymentPlanDto
            {
                Interest = 利息,
                OrderNumber = 1,
                Principal = transAmount,
                PrincipalAndInterest = transAmount + 利息,
                RemainingPrincipal = 0,
                RepaymentDate = endDate,
            };
            list.Add(temppPlan);
            return list;
        }

        public const RepaymentWay CalculatorName = RepaymentWay.一次性;

    }
}