﻿using Abp.Application.Navigation;
using Abp.Localization;
using Pgpg.Authorization;
using Pgpg.Web.Startup;

namespace Pgpg.Web.Areas.Admin.Startup
{
    public class AdminNavigationProvider : NavigationProvider
    {
        public const string MenuName = "App";
        
        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));

            menu
                .AddItem(new MenuItemDefinition(
                    AdminPageNames.Host.Tenants,
                    L("Tenants"),
                    url: "Admin/Tenants",
                    icon: "icon-globe",
                    requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                ).AddItem(new MenuItemDefinition(
                    AdminPageNames.Host.Editions,
                    L("Editions"),
                    url: "Admin/Editions",
                    icon: "icon-grid",
                    requiredPermissionName: AppPermissions.Pages_Editions
                    )
                ).AddItem(new MenuItemDefinition(
                    AdminPageNames.Tenant.Dashboard,
                    L("Dashboard"),
                    url: "Admin/Dashboard",
                    icon: "icon-home",
                    requiredPermissionName: AppPermissions.Pages_Tenant_Dashboard
                    )
                ).AddItem(new MenuItemDefinition(
                    AdminPageNames.Common.Administration,
                    L("Administration"),
                    icon: "icon-wrench"
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Common.OrganizationUnits,
                        L("OrganizationUnits"),
                        url: "Admin/OrganizationUnits",
                        icon: "icon-layers",
                        requiredPermissionName: AppPermissions.Pages_Administration_OrganizationUnits
                        )
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Common.Roles,
                        L("Roles"),
                        url: "Admin/Roles",
                        icon: "icon-briefcase",
                        requiredPermissionName: AppPermissions.Pages_Administration_Roles
                        )
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Common.Users,
                        L("Users"),
                        url: "Admin/Users",
                        icon: "icon-people",
                        requiredPermissionName: AppPermissions.Pages_Administration_Users
                        )
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Common.Languages,
                        L("Languages"),
                        url: "Admin/Languages",
                        icon: "icon-flag",
                        requiredPermissionName: AppPermissions.Pages_Administration_Languages
                        )
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Common.AuditLogs,
                        L("AuditLogs"),
                        url: "Admin/AuditLogs",
                        icon: "icon-lock",
                        requiredPermissionName: AppPermissions.Pages_Administration_AuditLogs
                        )
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Host.Maintenance,
                        L("Maintenance"),
                        url: "Admin/Maintenance",
                        icon: "icon-wrench",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Maintenance
                        )
                    )
                    .AddItem(new MenuItemDefinition(
                        AdminPageNames.Host.Settings,
                        L("Settings"),
                        url: "Admin/HostSettings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Host_Settings
                        )
                    ).AddItem(new MenuItemDefinition(
                        AdminPageNames.Tenant.Settings,
                        L("Settings"),
                        url: "Admin/Settings",
                        icon: "icon-settings",
                        requiredPermissionName: AppPermissions.Pages_Administration_Tenant_Settings
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PgpgConsts.LocalizationSourceName);
        }
    }
}