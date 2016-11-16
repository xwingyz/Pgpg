using System;
using System.Collections.Generic;
using System.Linq;
using Pgpg.Credit.Dto;
using Pgpg.Credit.Utility;

namespace Pgpg.Credit.Service
{
    public class AverageCapitalPlusInterestCalculator : CalculatorBase
    {
        public override List<CreditRepaymentPlanDto> CalculationIncome(DateTime startDate, DateTime endDate, decimal transAmount, decimal rate)
        {
            var list = new List<CreditRepaymentPlanDto>();
            var 月利率 = rate / 12;
            var 期数 = 0;
            DateTime tempDate = startDate;
            while (tempDate < endDate)
            {
                期数++;
                tempDate = tempDate.AddMonths(1);
            }
            var 每月还 = (transAmount * 月利率 * (1 + 月利率).Pow(期数) /
                       ((1 + 月利率).Pow(期数) - 1)).ToFixed(2);
            decimal 剩余本金 = transAmount;
            for (int i = 1; i < 期数 + 1; i++)
            {
                DateTime 当前期起始日 = startDate.AddMonths((i - 1) * 1);
                DateTime 满月日 = 当前期起始日.AddMonths(1);
                DateTime 当前期还款日 = 满月日 >= endDate ? endDate : 满月日;
                var 月利息 = 满月日 > endDate ? 按天计算利息(剩余本金, 月利率 / 30, (当前期还款日 - 当前期起始日).Days).ToFixed(2) : 按月计算利息(剩余本金, 月利率, 1).ToFixed(2);
                var 月本金 = 每月还 - 月利息;
                if (i == 期数)
                {
                    var tempAmount = list.Sum(r => r.Principal) + 月本金;
                    if (tempAmount > transAmount)
                    {
                        月本金 -= tempAmount - transAmount;
                    }
                    else if (tempAmount < transAmount)
                    {
                        月本金 += transAmount - tempAmount;
                    }
                }
                剩余本金 -= 月本金;
                list.Add(new CreditRepaymentPlanDto
                {
                    Interest = 月利息,
                    OrderNumber = i,
                    Principal = 月本金,
                    PrincipalAndInterest = 月本金 + 月利息,
                    RemainingPrincipal = 剩余本金,
                    RepaymentDate = 当前期还款日
                });
            }
            return list;
        }
        public const RepaymentWay CalculatorName = RepaymentWay.等额本息;
    }
}