// <auto-generated />
namespace Pgpg.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Upgrade_Abp_And_Module_Zero_To_0_7_3 : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Upgrade_Abp_And_Module_Zero_To_0_7_3));
        
        string IMigrationMetadata.Id
        {
            get { return "201510141938232_Upgrade_Abp_And_Module_Zero_To_0_7_3"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
