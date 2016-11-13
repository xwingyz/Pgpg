using System.Collections.Generic;
using Pgpg.Application.Authorization.Permissions.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}