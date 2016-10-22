using System.ComponentModel.DataAnnotations;

namespace Pgpg.Address.Country.Dto
{
    public class CreateOrUpdateCountryInput
    {
        [Required]
        public CountryEditDto Country { get; set; }
    }
}