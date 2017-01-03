using Abp.Dependency;

namespace Pgpg.Credit.Service
{
    /// <summary>
    /// 还款计划业务接口
    /// </summary>
    public interface IRepaymentPlanService:ITransientDependency
    {
        /// <summary>
        /// 创建标的还款计划
        /// </summary>
        /// <param name="creditId"></param>
        void CreateCreditRepaymentPlans(int creditId);
        /// <summary>
        /// 创建投资人的回款计划
        /// </summary>
        /// <param name="bidId">投标记录Id</param>
        bool CreateInvestorRepaymentPlans(int bidId);

    }
}