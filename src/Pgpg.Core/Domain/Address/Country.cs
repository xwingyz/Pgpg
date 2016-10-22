using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace Pgpg.Domain.Address
{
    [Table("Country")]
    public class Country: Entity,IPassivable
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
}
