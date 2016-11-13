using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;

namespace Pgpg.Core.Domain.Users
{
    [Table("FamilyMap")]
    public class FamilyMap: CreationAuditedEntity<long>
    {
        /// <summary>
        /// �ҳ��û�Id
        /// </summary>
        public long ParentUserId { get; set; }
        /// <summary>
        /// �����û�Id
        /// </summary>
        public long ChildrenUserId { get; set; }
    }
}