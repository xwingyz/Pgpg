using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Pgpg.Address.Country.Dto;

namespace Pgpg.Address.Country
{
    public class CountryAppService : PgpgAppServiceBase, ICountryAppService
    {
        private readonly IRepository<Domain.Address.Country> _countryRepository;

        public CountryAppService(IRepository<Domain.Address.Country> countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        public async Task<ListResultDto<CountryListDto>> GetCountries(GetCountriesInput input)
        {
            var countries = await _countryRepository.GetAll().ToListAsync();
            return countries.MapTo<Domain.Address.Country, CountryListDto>();
        }

        public async Task<GetCountryForEditOutput> GetCountryForEdit(NullableIdDto input)
        {
            CountryEditDto dto;
            if (input.Id.HasValue)
            {
                dto = (await _countryRepository.GetAsync(input.Id.Value)).MapTo<CountryEditDto>();
            }
            else
            {
                dto = new CountryEditDto();
            }
            return new GetCountryForEditOutput() { Country = dto };
        }

        public async Task CreateOrUpdateCountry(CreateOrUpdateCountryInput input)
        {
            if (input.Country.Id.HasValue)
            {
                Debug.Assert(input.Country.Id != null, "input.Country.Id should be set.");

                var country = await _countryRepository.GetAsync(input.Country.Id.Value);
                if (country.Name != input.Country.Name)
                {
                    if (await IsExistCountry(input.Country))
                    {
                        throw new UserFriendlyException(L("CountryAlreadyExists"));
                    }
                }
                country = input.Country.MapTo(country);
                await _countryRepository.UpdateAsync(country);
            }
            else
            {
                if (await IsExistCountry(input.Country))
                {
                    throw new UserFriendlyException(L("CountryAlreadyExists"));
                }
                var country = input.Country.MapTo<Domain.Address.Country>();
                await _countryRepository.InsertAsync(country);
            }
        }

        public async Task DeleteCountry(EntityDto input)
        {
            var country = await _countryRepository.GetAsync(input.Id);
            await _countryRepository.DeleteAsync(country);
        }

        protected async Task<bool> IsExistCountry(CountryEditDto country)
        {
            return (await _countryRepository.CountAsync(c => c.Name == country.Name)) > 0;
        }



    }
}