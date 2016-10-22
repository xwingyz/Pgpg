using Abp.AutoMapper;
using Pgpg.Address.Country.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Country
{
    [AutoMapFrom(typeof(GetCountryForEditOutput))]
    public class CreateOrEditCountryModalViewModel : GetCountryForEditOutput
    {
        public CreateOrEditCountryModalViewModel(GetCountryForEditOutput output)
        {
            output.MapTo(this);
        }
        public bool IsEditMode
        {
            get { return Country.Id.HasValue; }
        }
    }
}
