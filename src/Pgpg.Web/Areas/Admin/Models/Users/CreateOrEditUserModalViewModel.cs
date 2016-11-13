using System.Linq;
using Abp.AutoMapper;
using Pgpg.Application.Authorization.Users.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Users
{
    [AutoMapFrom(typeof (GetUserForEditOutput))]
    public class CreateOrEditUserModalViewModel : GetUserForEditOutput
    {
        public bool CanChangeUserName
        {
            get { return User.UserName != Core.Authorization.Users.User.AdminUserName; }
        }

        public int AssignedRoleCount
        {
            get { return Roles.Count(r => r.IsAssigned); }
        }

        public bool IsEditMode
        {
            get { return User.Id.HasValue; }
        }

        public CreateOrEditUserModalViewModel(GetUserForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}