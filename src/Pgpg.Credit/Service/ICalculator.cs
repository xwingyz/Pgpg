using System;
using System.Collections.Generic;
using Abp.Dependency;
using Pgpg.Credit.Dto;

namespace Pgpg.Credit.Service
{
    public interface ICalculator
    {
        List<CreditRepaymentPlanDto> CalculationIncome(DateTime starDate, DateTime endDate, decimal amount, decimal rate);

    }
}