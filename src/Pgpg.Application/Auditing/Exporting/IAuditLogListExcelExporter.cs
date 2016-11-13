using System.Collections.Generic;
using Pgpg.Application.Auditing.Dto;
using Pgpg.Application.Dto;

namespace Pgpg.Application.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
