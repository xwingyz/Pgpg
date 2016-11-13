using System.Collections.Generic;
using Pgpg.Application.Authorization.Permissions.Dto;

namespace Pgpg.Application.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}