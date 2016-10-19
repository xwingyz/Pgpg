using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Pgpg.Editions.Dto;

namespace Pgpg.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}