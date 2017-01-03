using System.ComponentModel.DataAnnotations;

namespace Pgpg.Application.Address.Country.Dto
{
    public class CreateOrUpdateCountryInput
    {
        [Required]
        public CountryEditDto Country { get; set; }
    }
}