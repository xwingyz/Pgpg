using Abp.Authorization;
using Pgpg.Core.Authorization.Roles;
using Pgpg.Core.Authorization.Users;
using Pgpg.Core.MultiTenancy;

namespace Pgpg.Core.Authorization
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
