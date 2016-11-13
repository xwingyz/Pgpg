using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;

namespace Pgpg.Core
{
    public static class AutoMapExtensions
    {
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static IReadOnlyList<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return source.Select(s => s.MapTo<TDestination>()).ToList();
        }

    }
}