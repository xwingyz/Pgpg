using System.ComponentModel.DataAnnotations;
using Pgpg.Authorization.Users;

namespace Pgpg.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}