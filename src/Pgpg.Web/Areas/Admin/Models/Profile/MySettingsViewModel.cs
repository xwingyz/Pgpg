using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pgpg.Application.Authorization.Users.Profile.Dto;
using Pgpg.Core.Authorization.Users;

namespace Pgpg.Web.Areas.Admin.Models.Profile
{
    [AutoMapFrom(typeof (CurrentUserProfileEditDto))]
    public class MySettingsViewModel : CurrentUserProfileEditDto
    {
        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public bool CanChangeUserName
        {
            get { return UserName != User.AdminUserName; }
        }

        public MySettingsViewModel(CurrentUserProfileEditDto currentUserProfileEditDto)
        {
            currentUserProfileEditDto.MapTo(this);
        }
    }
}