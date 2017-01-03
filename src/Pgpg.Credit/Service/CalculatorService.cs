using System;
using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Dependency;
using Pgpg.Credit.Dto;
using Pgpg.Credit.Utility;

namespace Pgpg.Credit.Service
{
    /// <summary>
    /// 计算器业务
    /// </summary>
    public class CalculatorService :ApplicationService, ICalculatorService
    {
        /// <summary>
        /// 复利计算
        /// </summary>
        /// <param name="starDate">开始投资日期</param>
        /// <param name="endDate">结束投资日期</param>
        /// <param name="amount">投资金额</param>
        /// <param name="rate">年利率</param>
        /// <returns></returns>
        public decimal CalculationCompoundInterest(DateTime starDate, DateTime endDate, decimal amount, decimal rate)
        {
            int count = 1;
            while (starDate.AddMonths(count + 1) <= endDate)
            {
                count++;
            }
            decimal rs = 0;
            rs += amount * ((1 + rate / 12).Pow(count));
            return rs.ToFixed(2);
        }

       

        public decimal 测试复利()
        {
            DateTime starTime = DateTime.Now.Date;
            DateTime endTime = DateTime.Now.Date.AddYears(5);
            decimal rs = 0;
            do
            {
                decimal amount = 16000;
                Console.WriteLine("{0}至{1},本金投资{2}", starTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"),
                    amount.ToString("N2"));
                rs += CalculationCompoundInterest(starTime, endTime, amount, 0.18m);
                starTime = starTime.AddMonths(1);
            } while (starTime < endTime);
            Console.WriteLine("5年总收益{0}", rs);
            return rs;
        }

        /// <summary>
        /// 计算收益
        /// </summary>
        /// <param name="repaymentWay">还款方式</param>
        /// <param name="starDate">开始投资日期</param>
        /// <param name="endDate">结束投资日期</param>
        /// <param name="amount">投资金额</param>
        /// <param name="rate">年利率</param>
        /// <returns>还款计划</returns>
        public List<CreditRepaymentPlanDto> CalculationIncome(RepaymentWay repaymentWay, DateTime starDate, DateTime endDate, decimal amount, decimal rate)
        {
            var calculator = IocManager.Instance.IocContainer.Resolve<ICalculator>(repaymentWay.ToString());
            var list = calculator.CalculationIncome(starDate, endDate, amount, rate);
            return list;
        }
    }
}