﻿using System.Data.Entity;

namespace Pgpg.EntityFramework
{
    public class PgpgDbConfiguration : DbConfiguration
    {
        public PgpgDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
