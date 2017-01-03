using System.Collections.Generic;
using Pgpg.Application.Authorization.Users.Dto;
using Pgpg.Application.Dto;

namespace Pgpg.Application.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}