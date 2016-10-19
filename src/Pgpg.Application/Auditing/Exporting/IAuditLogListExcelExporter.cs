using System.Collections.Generic;
using Pgpg.Auditing.Dto;
using Pgpg.Dto;

namespace Pgpg.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
