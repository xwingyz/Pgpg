using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace Pgpg.Core.XiaoShuo
{
    /// <summary>
    /// 小说章节
    /// </summary>
    public class Chapter : FullAuditedEntity
    {
        /// <summary>
        /// 章节名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 章节序号
        /// </summary>
        [Required]
        public int Number { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Content { get; set; }

    }
}
