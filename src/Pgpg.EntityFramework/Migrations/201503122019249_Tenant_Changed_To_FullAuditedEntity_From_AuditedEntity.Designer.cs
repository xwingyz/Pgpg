﻿// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;

namespace Pgpg.EntityFramework.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class Tenant_Changed_To_FullAuditedEntity_From_AuditedEntity : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201503122019249_Tenant_Changed_To_FullAuditedEntity_From_AuditedEntity"; }
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