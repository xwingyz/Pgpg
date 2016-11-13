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
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }

        public DateTime CreationTime { get; set; }

        public SmartDevice()
        {
            CreationTime = Clock.Now;
        }
    }
}