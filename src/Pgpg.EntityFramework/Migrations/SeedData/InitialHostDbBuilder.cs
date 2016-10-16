using Pgpg.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Pgpg.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PgpgDbContext _context;

        public InitialHostDbBuilder(PgpgDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
