using Abp.AutoMapper;
using Pgpg.MultiTenancy;
using Pgpg.MultiTenancy.Dto;
using Pgpg.Web.Areas.Admin.Models.Common;

namespace Pgpg.Web.Areas.Admin.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}