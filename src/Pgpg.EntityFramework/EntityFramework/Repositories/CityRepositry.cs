using System.Collections.Generic;
using System.Linq;
using Abp.EntityFramework;
using Pgpg.Domain.Address;
using Pgpg.IRepositories;

namespace Pgpg.EntityFramework.Repositories
{
    public class CityRepositry : PgpgRepositoryBase<City>, ICityRepositry
    {
        public CityRepositry(IDbContextProvider<PgpgDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<City> GetCities(int stateProvinceId)
        {
            return Table.Where(c => c.StateProvinceId == stateProvinceId);
        }
    }
}