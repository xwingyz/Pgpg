using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Pgpg.Domain.Address
{
    [Table("City")]
    public class City : Entity, IPassivable
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public int StateProvinceId { get; set; }

        public bool IsActive { get; set; }
    }
}
