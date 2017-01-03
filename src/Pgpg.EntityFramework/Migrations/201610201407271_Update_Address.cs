using System.Data.Entity.Migrations;

namespace Pgpg.EntityFramework.Migrations
{
    public partial class Update_Address : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.City", "Code", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Country", "Code", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.StateProvince", "Code", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StateProvince", "Code");
            DropColumn("dbo.Country", "Code");
            DropColumn("dbo.City", "Code");
        }
    }
}
