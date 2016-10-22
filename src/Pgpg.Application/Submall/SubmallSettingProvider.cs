using System.Collections.Generic;
using Abp.Configuration;

namespace Pgpg.Submall
{
    public class SubmallSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(
                    SubmallSettingNames.AppId,
                    "12214", scopes: SettingScopes.Application | SettingScopes.Tenant
                    ),

                new SettingDefinition(
                    SubmallSettingNames.AppKey,
                    "72de6df7da147cec1dc439cfa42c7c51", scopes: SettingScopes.Application | SettingScopes.Tenant
                    ),

                new SettingDefinition(
                    SubmallSettingNames.Title,
                    "美凌格", scopes: SettingScopes.Application | SettingScopes.Tenant
                    ),
                 new SettingDefinition(
                    SubmallSettingNames.MobileTrafficPackageAppId,
                    "10102", scopes: SettingScopes.Application | SettingScopes.Tenant
                    )
            };
        }
    }
}