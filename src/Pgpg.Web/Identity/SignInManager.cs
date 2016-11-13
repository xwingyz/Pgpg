using Abp.Configuration;
using Abp.Domain.Uow;
using Abp.Zero.AspNetCore;
using Microsoft.AspNetCore.Http;
using Pgpg.Core.Authorization.Roles;
using Pgpg.Core.Authorization.Users;
using Pgpg.Core.MultiTenancy;

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
