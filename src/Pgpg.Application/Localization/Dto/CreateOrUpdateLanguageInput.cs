using System.ComponentModel.DataAnnotations;

namespace Pgpg.Application.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}