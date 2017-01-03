using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Pgpg.Core.Domain.Messages
{
    [Table("WarningMessage")]
    public class WarningMessage: Entity<long>, IHasCreationTime
    {
        public long ChildrenUserId { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// ��ȫԤ��/Σ��Ԥ��/����Σ��Ԥ��
        /// </summary>
        public int Level { get; set; }

        public int Status { get; set; }
        public DateTime CreationTime { get; set; }
        public WarningMessage()
        {
            CreationTime = Clock.Now;
        }
    }
}