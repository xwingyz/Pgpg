using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using Pgpg.Authorization.Roles;
using Pgpg.Authorization.Users;
using Pgpg.Chat;
using Pgpg.Configuration;
using Pgpg.Friendships;
using Pgpg.MultiTenancy;
using Pgpg.Storage;
using Pgpg.Web;

namespace Pgpg.EntityFramework
{
    [DbConfigurationType(typeof(PgpgDbConfiguration))]
    public class PgpgDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

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