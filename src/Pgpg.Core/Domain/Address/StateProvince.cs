using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Pgpg.Core.Domain.Address
{
    [Table("StateProvince")]
    public class StateProvince:Entity,IPassivable
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public int CountryId { get; set; }

        public bool IsActive { get; set; }
    }
}
