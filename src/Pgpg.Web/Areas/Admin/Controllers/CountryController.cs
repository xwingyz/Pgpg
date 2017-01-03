using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Application.Address.Country;
using Pgpg.Core.Authorization;
using Pgpg.Web.Areas.Admin.Models.Country;

namespace Pgpg.Web.Areas.Admin.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Countries)]
    public class CountryController : AdminControllerBase
    {
        private readonly ICountryAppService _countryAppService;

        public CountryController(ICountryAppService countryAppService)
        {
            _countryAppService = countryAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Countries_Create, AppPermissions.Pages_Countries_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _countryAppService.GetCountryForEdit(new NullableIdDto { Id = id });
            var viewModel = new CreateOrEditCountryModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }
    }
}