using System.Reflection;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Modules;
using Pgpg.Application.Submall;
using Pgpg.Core;
using Pgpg.Core.Authorization;
using Pgpg.Core.Debugging;
using Pgpg.Core.Smsing;

namespace Pgpg.Application
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

            if (DebugHelper.IsDebug)
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