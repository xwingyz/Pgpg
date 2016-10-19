using EntityFramework.DynamicFilters;
using Pgpg.EntityFramework;

namespace Pgpg.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly PgpgDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(PgpgDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
