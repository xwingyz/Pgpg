using System;
using Abp.Application.Services;

namespace Pgpg.Credit.Service
{
    public class RepaymentPlanService : ApplicationService, IRepaymentPlanService
    {
        public void CreateCreditRepaymentPlans(int creditId)
        {
            throw new NotImplementedException();
        }

        public bool CreateInvestorRepaymentPlans(int bidId)
        {
            throw new NotImplementedException();
        }
    }
}