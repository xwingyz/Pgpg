using System.Collections.Generic;
using Pgpg.Authorization.Users.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}