using Abp.AutoMapper;
using Pgpg.Application.Authorization.Users.Dto;
using Pgpg.Core.Authorization.Users;
using Pgpg.Web.Areas.Admin.Models.Common;

namespace Pgpg.Web.Areas.Admin.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}