using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;

namespace Pgpg.Core
{
    public static class AutoMapExtensions
    {
        /// <summary>
        /// �����б�����ӳ��
        /// </summary>
        public static IReadOnlyList<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return source.Select(s => s.MapTo<TDestination>()).ToList();
        }

    }
}