using System.Collections.Generic;
using Pgpg.Authorization.Users.Dto;
using Pgpg.Dto;

namespace Pgpg.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}