using System.IO;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Auditing;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Application.Dto;
using Pgpg.Core;

namespace Pgpg.Web.Controllers
{
    public class FileController : PgpgControllerBase
    {
        private readonly IAppFolders _appFolders;

        public FileController(IAppFolders appFolders)
        {
            _appFolders = appFolders;
        }

        [AbpMvcAuthorize]
        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, file.FileToken);
            if (!System.IO.File.Exists(filePath))
            {
                throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            System.IO.File.Delete(filePath);
            return File(fileBytes, file.FileType, file.FileName);
        }
    }
}