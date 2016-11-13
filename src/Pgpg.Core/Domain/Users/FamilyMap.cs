using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Pgpg.Core.Domain.Users
{
    [Table("FamilyMap")]
    public class FamilyMap: CreationAuditedEntity<long>
    {
        /// <summary>
        /// 家长用户Id
        /// </summary>
        public long ParentUserId { get; set; }
        /// <summary>
        /// 孩子用户Id
        /// </summary>
        public long ChildrenUserId { get; set; }
    }
}