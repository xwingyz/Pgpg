using System.ComponentModel.DataAnnotations;
using Pgpg.Authorization.Users;

namespace Pgpg.Configuration.Host.Dto
{
    public class SendTestSmsInput
    {
        [Required]
        [MaxLength(User.MaxPhoneNumberLength)]
        public string Phone { get; set; }
    }
}