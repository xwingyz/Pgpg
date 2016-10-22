using System.Text.RegularExpressions;
using Abp.Extensions;

namespace Pgpg.Validation
{
    public class ValidationHelper
    {
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public bool IsEmail(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var regex = new Regex(EmailRegex);
            return regex.IsMatch(value);
        }
        //todo 手机号正则表达式
        public const string PhoneRegex = @"^1(3[0-9]|4[57]|5[0-35-9]|7[01678]|8[0-9])\d{8}$";
        public bool IsPhoneNumber(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            var regex = new Regex(PhoneRegex);
            return regex.IsMatch(value);
        }
        /// <summary> 
        /// 匹配移动手机号 
        /// </summary> 
        public const string ChinaMobilePattern = @"^1(3[4-9]|4[7]|5[0-27-9]|7[08]|8[2-478])\d{8}$";
        /// <summary>
        /// 是否中国移动手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsChinaMobilePhoneNumber(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }
            var regex = new Regex(ChinaMobilePattern);
            return regex.IsMatch(value);
        }
        /// <summary> 
        /// 匹配联通手机号 
        /// </summary> 
        public const string ChinaUnicomPattern = @"^1(3[0-2]|4[5]|5[256]|7[016]|8[56])\d{8}$";
        /// <summary>
        /// 是否中国联通手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsChinaUnicomPhoneNumber(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }
            var regex = new Regex(ChinaUnicomPattern);
            return regex.IsMatch(value);
        }
        /// <summary> 
        /// 匹配电信手机号 
        /// </summary> 
        public const string ChinaTelecomPattern = @"^1(3[34]|53|7[07]|8[019])\d{8}$";
        /// <summary>
        /// 是否中国电信手机号码
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsChinaTelecomPhoneNumber(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }
            var regex = new Regex(ChinaTelecomPattern);
            return regex.IsMatch(value);
        }
    }
}
