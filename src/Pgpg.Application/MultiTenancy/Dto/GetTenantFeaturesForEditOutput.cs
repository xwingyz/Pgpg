using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Pgpg.Application.Editions.Dto;

namespace Pgpg.Application.MultiTenancy.Dto
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}