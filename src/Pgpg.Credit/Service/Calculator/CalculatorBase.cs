using System;
using System.Collections.Generic;
using Pgpg.Credit.Dto;
using Pgpg.Credit.Utility;

namespace Pgpg.Credit.Service
{
    public abstract class CalculatorBase : ICalculator
    {
        public abstract List<CreditRepaymentPlanDto> CalculationIncome(DateTime startDate, DateTime endDate, decimal transAmount, decimal rate);


        protected decimal 按天计算利息(decimal 借款金额, decimal 天利率, int 借款天数)
        {
            var 利息 = (借款金额 * 天利率 * 借款天数).ToFixed(4);
            return 利息;
        }

        protected decimal 按月计算利息(decimal 借款金额, decimal 月利率, int 借款月数)
        {
            var 利息 = (借款金额 * 月利率 * 借款月数).ToFixed(4);
            return 利息;
        }
    }
}