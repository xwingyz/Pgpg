using System.Collections.Generic;
using Pgpg.Authorization.Permissions.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}