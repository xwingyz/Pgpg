using Abp.Configuration;
using Abp.Domain.Uow;
using Abp.Zero.AspNetCore;
using Microsoft.AspNetCore.Http;
using Pgpg.Authorization.Roles;
using Pgpg.Authorization.Users;
using Pgpg.MultiTenancy;

namespace Pgpg.Web.Identity
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager,
            IHttpContextAccessor contextAccessor, 
            ISettingManager settingManager, 
            IUnitOfWorkManager unitOfWorkManager,
            IAbpZeroAspNetCoreConfiguration configuration) 
            : base(
                  userManager,
                  contextAccessor, 
                  settingManager, 
                  unitOfWorkManager,
                  configuration)
        {
        }
    }
}
