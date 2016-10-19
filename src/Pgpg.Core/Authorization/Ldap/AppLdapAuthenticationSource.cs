using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Pgpg.Authorization.Users;
using Pgpg.MultiTenancy;

namespace Pgpg.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
