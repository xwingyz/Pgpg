using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Pgpg.Credit.Domain
{
    [Table("Credit")]
    public class Credit : FullAuditedEntity<long>, IPassivable
    {
        public bool IsActive { get; set; }
    }
    [Table("Investment")]
    public class Investment : FullAuditedEntity<long>, IPassivable
    {
        public bool IsActive { get; set; }
    }
}
