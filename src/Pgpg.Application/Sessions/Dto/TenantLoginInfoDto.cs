using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Pgpg.Core.MultiTenancy;

namespace Pgpg.Application.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public string EditionDisplayName { get; set; }
    }
}