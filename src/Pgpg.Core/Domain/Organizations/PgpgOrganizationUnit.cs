using Abp.Organizations;

namespace Pgpg.Core.Domain.Organizations
{
    public class PgpgOrganizationUnit : OrganizationUnit
    {
        public string Address { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public string Coordinates { get; set; }

    }
}