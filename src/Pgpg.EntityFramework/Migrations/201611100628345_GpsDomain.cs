namespace Pgpg.EntityFramework.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class GpsDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyMap",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParentUserId = c.Long(nullable: false),
                        ChildrenUserId = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GpsRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DeviceId = c.String(),
                        Coordinates = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmartDevice",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                        DeviceType = c.String(),
                        DeviceName = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SmsRecord",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ParentUserId = c.Long(nullable: false),
                        ChildrenUserId = c.Long(nullable: false),
                        Phone = c.String(),
                        Message = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WarningMessage",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChildrenUserId = c.Long(nullable: false),
                        Message = c.String(),
                        Level = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterTableAnnotations(
                "dbo.AbpOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 95),
                        DisplayName = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Address = c.String(),
                        Phone = c.String(),
                        Coordinates = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_PgpgOrganizationUnit_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                    { 
                        "DynamicFilter_PgpgOrganizationUnit_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.AbpOrganizationUnits", "Address", c => c.String());
            AddColumn("dbo.AbpOrganizationUnits", "Phone", c => c.String());
            AddColumn("dbo.AbpOrganizationUnits", "Coordinates", c => c.String());
            AddColumn("dbo.AbpOrganizationUnits", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AbpUsers", "NickName", c => c.String());
            AddColumn("dbo.AbpUsers", "Birthday", c => c.DateTime());
            AddColumn("dbo.AbpUsers", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUsers", "Sex");
            DropColumn("dbo.AbpUsers", "Birthday");
            DropColumn("dbo.AbpUsers", "NickName");
            DropColumn("dbo.AbpOrganizationUnits", "Discriminator");
            DropColumn("dbo.AbpOrganizationUnits", "Coordinates");
            DropColumn("dbo.AbpOrganizationUnits", "Phone");
            DropColumn("dbo.AbpOrganizationUnits", "Address");
            AlterTableAnnotations(
                "dbo.AbpOrganizationUnits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        ParentId = c.Long(),
                        Code = c.String(nullable: false, maxLength: 95),
                        DisplayName = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Address = c.String(),
                        Phone = c.String(),
                        Coordinates = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_PgpgOrganizationUnit_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                    { 
                        "DynamicFilter_PgpgOrganizationUnit_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropTable("dbo.WarningMessage");
            DropTable("dbo.SmsRecord");
            DropTable("dbo.SmartDevice");
            DropTable("dbo.GpsRecord");
            DropTable("dbo.FamilyMap");
        }
    }
}
