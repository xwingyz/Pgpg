using System.Collections.Generic;
using Pgpg.Authorization.Permissions.Dto;

namespace Pgpg.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}