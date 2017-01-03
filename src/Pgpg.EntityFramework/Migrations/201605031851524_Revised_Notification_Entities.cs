using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Revised_Notification_Entities : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.AbpUserNotifications", "NotificationId", "TenantNotificationId");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.AbpUserNotifications", "TenantNotificationId", "NotificationId");
        }
    }
}
