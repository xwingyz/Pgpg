namespace Pgpg.Credit.Service
{
    /// <summary>
    /// 还款方式
    /// </summary>
    public enum RepaymentWay
    {
        先息后本 = 1,
        一次性 = 2,
        等额本息 = 3
    }

    /// <summary>
    /// 借款周期类型
    /// </summary>
    public enum DateType
    {
        天 = 1,
        月 = 2
    }
}
