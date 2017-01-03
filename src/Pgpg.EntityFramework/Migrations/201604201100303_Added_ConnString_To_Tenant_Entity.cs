using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Added_ConnString_To_Tenant_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpTenants", "ConnectionString", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpTenants", "ConnectionString");
        }
    }
}
