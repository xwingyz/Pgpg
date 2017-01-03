using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using Pgpg.Core;
using Pgpg.Core.Authorization.Roles;
using Pgpg.Core.Authorization.Users;
using Pgpg.Core.Chat;
using Pgpg.Core.Configuration;
using Pgpg.Core.Domain.Address;
using Pgpg.Core.Domain.Devices;
using Pgpg.Core.Domain.Gps;
using Pgpg.Core.Domain.Messages;
using Pgpg.Core.Domain.Users;
using Pgpg.Core.Friendships;
using Pgpg.Core.MultiTenancy;
using Pgpg.Core.Storage;
using Pgpg.Core.Web;

namespace Pgpg.EntityFramework.EntityFramework
{
    [DbConfigurationType(typeof(PgpgDbConfiguration))]
    public class PgpgDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<StateProvince> StateProvinces { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<SmartDevice> SmartDevices { get; set; }
        public virtual IDbSet<GpsRecord> GpsRecords { get; set; }
        public virtual IDbSet<SmsRecord> SmsRecords { get; set; }
        public virtual IDbSet<WarningMessage> WarningMessages { get; set; }
        public virtual IDbSet<FamilyMap> FamilyMaps { get; set; }

        /* Default constructor is needed for EF command line tool. */
        public PgpgDbContext()
            : base(GetConnectionString())
        {
            
        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                PgpgConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string defined in PgpgDataModule.PreInitialize.
         * Notice that, actually you will not directly create an instance of PgpgDbContext since ABP automatically handles it.
         */
        public PgpgDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public PgpgDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }
}