using System.ComponentModel.DataAnnotations;
using Pgpg.Core.Authorization.Users;

namespace Pgpg.Application.Configuration.Host.Dto
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}