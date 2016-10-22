using System.Linq;
using Abp.Domain.Repositories;
using Pgpg.Domain.Address;

namespace Pgpg.IRepositories
{
    public interface ICityRepositry : IRepository<City>
    {
        IQueryable<City> GetCities(int stateProvinceId);
    }
}