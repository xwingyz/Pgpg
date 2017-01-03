using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Upgraded_To_Module_Zero_0_7_7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpAuditLogs", "CustomData", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpAuditLogs", "CustomData", c => c.String());
        }
    }
}
