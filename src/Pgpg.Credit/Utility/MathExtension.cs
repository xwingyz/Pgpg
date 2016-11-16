using System;
using System.ComponentModel.DataAnnotations;

namespace Pgpg.Credit.Utility
{
    public static class MathExtension
    {
        /// <summary> 
        /// 将小数值按指定的小数位数截断 
        /// </summary> 
        /// <param name="d">要截断的小数</param> 
        /// <param name="s">小数位数，s大于等于0，小于等于28</param> 
        /// <returns></returns> 
        public static decimal ToFixed(this decimal d, int s)
        {
            decimal sp = Convert.ToDecimal(Math.Pow(10, s));

            if (d < 0)
                return Math.Truncate(d) + Math.Ceiling((d - Math.Truncate(d)) * sp) / sp;
            else
                return Math.Truncate(d) + Math.Floor((d - Math.Truncate(d)) * sp) / sp;
        }

        /// <summary>
        /// 返回指定数字的指定次幂
        /// </summary>
        /// <param name="yuanshu">要乘幂的数字</param>
        /// <param name="mu">指定幂</param>
        /// <returns></returns>
        public static decimal Pow(this decimal yuanshu, int mu)
        {

            decimal yuanshu1 = yuanshu;
            while (--mu > 0)
            {
                yuanshu1 = yuanshu1 * yuanshu;
            }
            return yuanshu1;
        }
    }
}
