using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Pgpg.Core.Domain.Messages
{
    [Table("SmsRecord")]
    public class SmsRecord : Entity<long>, IHasCreationTime
    {
        public long ParentUserId { get; set; }

        public long ChildrenUserId { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public DateTime CreationTime { get; set; }

        public SmsRecord()
        {
            CreationTime = Clock.Now;
        }
    }
}