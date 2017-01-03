using Abp.Runtime.Validation;
using Pgpg.Application.Dto;

namespace Pgpg.Application.Address.Country.Dto
{
    public class GetCountriesInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public void Normalize()
        {
            Sorting = "Id";
        }
    }
}