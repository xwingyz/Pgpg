using Abp.Application.Services;

namespace Pgpg.Application.Submall
{
    /// <summary>
    /// 手机业务
    /// </summary>
    public interface IPhoneBusinessAppService : IApplicationService
    {
        /// <summary>
        /// 充值流量包
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="packageType"></param>
        /// <returns></returns>
        bool Charge(string phoneNumber, string packageType);

    }
}