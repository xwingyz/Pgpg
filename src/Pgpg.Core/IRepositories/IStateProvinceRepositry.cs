using System.Linq;
using Abp.Domain.Repositories;
using Pgpg.Core.Domain.Address;

namespace Pgpg.Core.IRepositories
{
    public interface IStateProvinceRepositry: IRepository<StateProvince>
    {
        IQueryable<StateProvince> GetStateProvinces(int countryId);
    }
}
