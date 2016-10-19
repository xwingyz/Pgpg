using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace Pgpg.Web.Areas.Admin.Models.Roles
{
    public class RoleListViewModel
    {
        public List<ComboboxItemDto> Permissions { get; set; }
    }
}