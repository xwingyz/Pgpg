using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Pgpg.Core.Domain.Gps
{
    [Table("GpsRecord")]
    public class GpsRecord : Entity<long>, IHasCreationTime
    {
        /// <summary>
        /// Éè±¸Id
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// ×ø±ê
        /// </summary>
        public string Coordinates { get; set; }

        public DateTime CreationTime { get; set; }

        public GpsRecord()
        {
            CreationTime = Clock.Now;
        }
    }
}