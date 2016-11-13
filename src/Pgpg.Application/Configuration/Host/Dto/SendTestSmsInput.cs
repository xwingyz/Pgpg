using System.ComponentModel.DataAnnotations;
using Pgpg.Core.Authorization.Users;

namespace Pgpg.Application.Configuration.Host.Dto
{
    public class SendTestSmsInput
    {
        [Required]
        [MaxLength(User.MaxPhoneNumberLength)]
        public string Phone { get; set; }
    }
}