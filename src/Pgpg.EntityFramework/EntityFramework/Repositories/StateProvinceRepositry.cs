using System.Linq;
using Abp.EntityFramework;
using Pgpg.Core.Domain.Address;
using Pgpg.Core.IRepositories;

namespace Pgpg.EntityFramework.EntityFramework.Repositories
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
