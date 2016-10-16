using System.Linq;
using Pgpg.EntityFramework;
using Pgpg.MultiTenancy;

namespace Pgpg.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly PgpgDbContext _context;

        public DefaultTenantCreator(PgpgDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
