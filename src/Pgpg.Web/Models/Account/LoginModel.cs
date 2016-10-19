using System.ComponentModel.DataAnnotations;
using Abp.Auditing;

namespace Pgpg.Web.Models.Account
{
    public class LoginModel
    {
        public string TenancyName { get; set; }

        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        [DisableAuditing]
        public string Password { get; set; }
    }
}