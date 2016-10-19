using System.Collections.Generic;
using Pgpg.Caching.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}