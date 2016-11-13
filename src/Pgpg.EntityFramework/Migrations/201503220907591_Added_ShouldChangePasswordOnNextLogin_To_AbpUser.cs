using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Added_ShouldChangePasswordOnNextLogin_To_AbpUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpUsers", "ShouldChangePasswordOnNextLogin", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "ShouldChangePasswordOnNextLogin");
        }
    }
}
