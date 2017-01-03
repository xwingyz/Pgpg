using Pgpg.Application.Dto;

namespace Pgpg.Application.Common.Dto
{
    public class FindUsersInput : PagedAndFilteredInputDto
    {
        public int? TenantId { get; set; }
    }
}