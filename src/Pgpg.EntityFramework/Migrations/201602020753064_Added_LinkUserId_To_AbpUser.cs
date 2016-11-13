using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Added_LinkUserId_To_AbpUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "UserLinkId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "UserLinkId");
        }
    }
}
