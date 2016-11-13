using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Added_Index_For_UserNotifications : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpUserNotifications", new[] { "UserId", "State", "CreationTime" });
        }
    }
}
