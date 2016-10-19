using System.IO;
using System.Reflection;
using Abp.Configuration.Startup;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Hangfire;
using Abp.IO;
using Abp.Modules;
using Abp.Runtime.Caching.Redis;
using Abp.Runtime.Session;
using Abp.Web.SignalR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;
using Pgpg.EntityFramework;
using Pgpg.Web.Areas.Admin.Startup;
using Pgpg.Web.Configuration;
using Pgpg.Web.Utils;
using Abp.Hangfire.Configuration;
using Hangfire;
using Abp.Reflection.Extensions;
using Abp.Zero.AspNetCore;

namespace Pgpg.Web.Startup
{
    [DependsOn(
        typeof(PgpgApplicationModule),
        typeof(PgpgEntityFrameworkModule),
        typeof(AbpAspNetCoreModule),
        typeof(AbpZeroAspNetCoreModule),
        typeof(AbpWebSignalRModule),
        typeof(AbpRedisCacheModule), //AbpRedisCacheModule dependency can be removed if not using Redis cache
        typeof(AbpHangfireModule))] //AbpHangfireModule dependency can be removed if not using Hangfire
    public class PgpgWebModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public PgpgWebModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PgpgConsts.ConnectionStringName
                );

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Get<IAbpZeroAspNetCoreConfiguration>().AuthenticationScheme = AuthConfigurer.AuthenticationScheme;

            Configuration.Navigation.Providers.Add<FrontEndNavigationProvider>();
            Configuration.Navigation.Providers.Add<AdminNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(PgpgApplicationModule).Assembly
                );

            //Uncomment these lines to use HangFire as background job manager, instead of default background job manager.
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage(Configuration.DefaultNameOrConnectionString);
            //});

            //Uncomment this line to use Redis cache instead of in-memory cache.
            //See app.config for Redis configuration and connection string
            //Configuration.Caching.UseRedis(options =>
            //{
            //    options.ConnectionString = _appConfiguration["Abp:RedisCache:ConnectionString"];
            //    options.DatabaseId = _appConfiguration.GetValue<int>("Abp:RedisCache:DatabaseId");
            //});
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            SetAppFolders();
        }

        private void SetAppFolders()
        {
            var appFolders = IocManager.Resolve<AppFolders>();

            appFolders.SampleProfileImagesFolder = Path.Combine(_env.WebRootPath, @"Common\Images\SampleProfilePics");
            appFolders.TempFileDownloadFolder = Path.Combine(_env.WebRootPath, @"Temp\Downloads");
            appFolders.WebLogsFolder = Path.Combine(_env.ContentRootPath, @"App_Data\Logs");

            if (_env.IsDevelopment())
            {
                var currentAssemblyDirectoryPath = Assembly.GetExecutingAssembly().GetDirectoryPathOrNull();
                if (currentAssemblyDirectoryPath != null)
                {
                    appFolders.WebLogsFolder = Path.Combine(currentAssemblyDirectoryPath, @"App_Data\Logs");
                }
            }

            try
            {
                DirectoryHelper.CreateIfNotExists(appFolders.TempFileDownloadFolder);
            }
            catch { }
        }
    }
}