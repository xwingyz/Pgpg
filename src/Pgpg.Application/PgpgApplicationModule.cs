using System.Reflection;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Pgpg.Authorization;
using Pgpg.Smsing;
using Pgpg.Submall;

namespace Pgpg
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(PgpgCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PgpgApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding setting providers
            Configuration.Settings.Providers.Add<SubmallSettingProvider>();

            if (Debugging.DebugHelper.IsDebug)
            {
                IocManager.Register<ISmsSender, NullSmsSender>(DependencyLifeStyle.Transient);
            }
            else
            {
                IocManager.Register<ISmsSender, SubmallSmsMessageService>(DependencyLifeStyle.Transient);
            }

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}