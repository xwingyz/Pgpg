using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using Pgpg.Configuration;
using Pgpg.EntityFramework;

namespace Pgpg.Migrator
{
    [DependsOn(typeof(PgpgEntityFrameworkModule))]
    public class PgpgMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public PgpgMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(PgpgMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<PgpgDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PgpgConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}