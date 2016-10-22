using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pgpg.Web.Areas.Admin.Startup
{
    public class AdminPageNames
    {
        public static class Common
        {
            public const string Administration = "Administration";
            public const string Roles = "Administration.Roles";
            public const string Users = "Administration.Users";
            public const string AuditLogs = "Administration.AuditLogs";
            public const string OrganizationUnits = "Administration.OrganizationUnits";
            public const string Languages = "Administration.Languages";

            public const string Country = "Country";
            public const string City = "City";
            public const string StateProvince = "StateProvince";
        }

        public static class Host
        {
            public const string Tenants = "Tenants";
            public const string Editions = "Editions";
            public const string Maintenance = "Administration.Maintenance";
            public const string Settings = "Administration.Settings.Host";

            public const string PhoneBusiness = "PhoneBusiness";

            

        }

        public static class Tenant
        {
            public const string Dashboard = "Dashboard.Tenant";
            public const string Settings = "Administration.Settings.Tenant";
        }
    }
}
