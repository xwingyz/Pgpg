using Abp.Authorization;
using Pgpg.Authorization.Roles;
using Pgpg.MultiTenancy;
using Pgpg.Users;

namespace Pgpg.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
