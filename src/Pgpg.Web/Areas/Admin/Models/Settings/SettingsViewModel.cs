using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Pgpg.Application.Configuration.Tenants.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}