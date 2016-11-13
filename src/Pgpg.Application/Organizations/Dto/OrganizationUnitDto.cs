using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Organizations;
using Pgpg.Core.Domain.Organizations;

namespace Pgpg.Application.Organizations.Dto
{
    [AutoMapFrom(typeof(OrganizationUnit), typeof(PgpgOrganizationUnit))]
    public class OrganizationUnitDto : AuditedEntityDto<long>
    {
        public long? ParentId { get; set; }

        public string Code { get; set; }

        public string DisplayName { get; set; }

        public int MemberCount { get; set; }
    }
}