using System;
using System.Linq;
using Abp.Domain.Repositories;
using Pgpg.Domain.Address;

namespace Pgpg.IRepositories
{
    public interface IStateProvinceRepositry: IRepository<StateProvince>
    {
        IQueryable<StateProvince> GetStateProvinces(int countryId);
    }
}
