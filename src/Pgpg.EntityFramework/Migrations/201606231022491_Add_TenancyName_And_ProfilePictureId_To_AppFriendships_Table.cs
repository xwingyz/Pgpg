using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Add_TenancyName_And_ProfilePictureId_To_AppFriendships_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppFriendships", "FriendTenancyName", c => c.String());
            AddColumn("dbo.AppFriendships", "FriendProfilePictureId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppFriendships", "FriendProfilePictureId");
            DropColumn("dbo.AppFriendships", "FriendTenancyName");
        }
    }
}
