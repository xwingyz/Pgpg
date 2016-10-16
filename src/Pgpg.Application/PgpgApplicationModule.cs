using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Pgpg.Authorization;

namespace Pgpg
{
    [DependsOn(
        typeof(PgpgCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PgpgApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PgpgAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}