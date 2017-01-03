using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;

namespace Pgpg.Core.Domain.Devices
{
    [Table("SmartDevice")]
    public class SmartDevice : Entity<string>,IHasCreationTime
    {
        /// <summary>
        /// �û�Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// �豸����
        /// </summary>
        public string DeviceType { get; set; }
        /// <summary>
        /// �豸����
        /// </summary>
        public string DeviceName { get; set; }

        public DateTime CreationTime { get; set; }

        public SmartDevice()
        {
            CreationTime = Clock.Now;
        }
    }
}