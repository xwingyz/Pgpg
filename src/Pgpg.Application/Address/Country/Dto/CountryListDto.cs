using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Pgpg.Application.Address.Country.Dto
{
    [AutoMap(typeof(Core.Domain.Address.Country))]
    public class CountryListDto : EntityDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
}