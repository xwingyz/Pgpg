using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Pgpg.Address.Country.Dto
{
    [AutoMap(typeof(Domain.Address.Country))]
    public class CountryListDto : EntityDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
}