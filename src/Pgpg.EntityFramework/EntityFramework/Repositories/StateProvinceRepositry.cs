using System.Linq;
using Abp.EntityFramework;
using Pgpg.Domain.Address;
using Pgpg.IRepositories;

namespace Pgpg.EntityFramework.Repositories
{
    public class StateProvinceRepositry : PgpgRepositoryBase<StateProvince>,IStateProvinceRepositry
    {
        public StateProvinceRepositry(IDbContextProvider<PgpgDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<StateProvince> GetStateProvinces(int countryId)
        {
            return Table.Where(s => s.CountryId == countryId);
        }
    }
}
