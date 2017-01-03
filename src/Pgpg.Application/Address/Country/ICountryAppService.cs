using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pgpg.Application.Address.Country.Dto;

namespace Pgpg.Application.Address.Country
{
    public interface ICountryAppService: IApplicationService
    {
        Task<ListResultDto<CountryListDto>> GetCountries(GetCountriesInput input);

        Task<PagedResultDto<CountryListDto>> GetCountryPagedList(GetCountriesInput input);

        Task CreateOrUpdateCountry(CreateOrUpdateCountryInput input);

        Task DeleteCountry(EntityDto input);

        Task<GetCountryForEditOutput> GetCountryForEdit(NullableIdDto input);
    }
}
