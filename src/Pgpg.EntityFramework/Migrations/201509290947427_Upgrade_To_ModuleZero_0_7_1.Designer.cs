// <auto-generated />
namespace Pgpg.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Upgrade_To_ModuleZero_0_7_1 : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Upgrade_To_ModuleZero_0_7_1));
        
        string IMigrationMetadata.Id
        {
            get { return "201509290947427_Upgrade_To_ModuleZero_0_7_1"; }
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
