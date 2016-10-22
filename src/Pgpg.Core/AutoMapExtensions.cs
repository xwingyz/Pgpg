using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
namespace Pgpg
{
    public static class AutoMapExtensions
    {
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static ListResultDto<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            return new ListResultDto<TDestination>() { Items = source.Select(s => s.MapTo<TDestination>()).ToList() };
        }
    }
}