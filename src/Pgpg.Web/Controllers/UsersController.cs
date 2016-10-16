using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Pgpg.Authorization;
using Pgpg.Users;
using Microsoft.AspNetCore.Mvc;

namespace Pgpg.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : PgpgControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            return View(output);
        }
    }
}