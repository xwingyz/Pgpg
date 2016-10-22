using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace Pgpg.Address.Country.Dto
{
    [AutoMap(typeof(Domain.Address.Country))]
    public class CountryEditDto: IPassivable
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }
    }
}
