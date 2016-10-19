using Abp.Authorization;
using Pgpg.Authorization.Roles;
using Pgpg.Authorization.Users;
using Pgpg.MultiTenancy;

namespace Pgpg.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
