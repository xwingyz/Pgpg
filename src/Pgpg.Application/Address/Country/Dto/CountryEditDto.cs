using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace Pgpg.Application.Address.Country.Dto
{
    [AutoMap(typeof(Core.Domain.Address.Country))]
    public class CountryEditDto: IPassivable
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
}
