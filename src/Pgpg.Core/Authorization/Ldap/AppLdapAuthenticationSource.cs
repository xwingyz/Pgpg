using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Pgpg.Core.Authorization.Users;
using Pgpg.Core.MultiTenancy;

namespace Pgpg.Core.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
