using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Pgpg.Core.XiaoShuo
{
    /// <summary>
    /// 小说
    /// </summary>
    public class Book : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// 简介 
        /// </summary>
        public string Introduction { get; set; }
    }

}
