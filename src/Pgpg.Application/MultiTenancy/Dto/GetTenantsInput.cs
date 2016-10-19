using Abp.Runtime.Validation;
using Pgpg.Dto;

namespace Pgpg.MultiTenancy.Dto
{
    public class GetTenantsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "TenancyName";
            }

            Sorting = Sorting.Replace("editionDisplayName", "Edition.DisplayName");
        }
    }
}

