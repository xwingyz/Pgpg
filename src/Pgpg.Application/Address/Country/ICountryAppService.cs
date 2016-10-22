using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pgpg.Address.Country.Dto;

namespace Pgpg.Address.Country
{
    public interface ICountryAppService: IApplicationService
    {
        Task<ListResultDto<CountryListDto>> GetCountries(GetCountriesInput input);

        Task CreateOrUpdateCountry(CreateOrUpdateCountryInput input);

        Task DeleteCountry(EntityDto input);

        Task<GetCountryForEditOutput> GetCountryForEdit(NullableIdDto input);
    }
}
