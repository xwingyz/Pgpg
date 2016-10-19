using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Auditing;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.IO.Extensions;
using Abp.Runtime.Session;
using Abp.UI;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Pgpg.Authorization.Users;
using Pgpg.Friendships;
using Pgpg.IO;
using Pgpg.Net.MimeTypes;
using Pgpg.Storage;

namespace Pgpg.Web.Controllers
{
    [AbpMvcAuthorize]
    [DisableAuditing]
    public class ProfileController : PgpgControllerBase
    {
        private readonly UserManager _userManager;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly IAppFolders _appFolders;
        private readonly IFriendshipManager _friendshipManager;

        public ProfileController(
            UserManager userManager,
            IBinaryObjectManager binaryObjectManager,
            IAppFolders appFolders,
            IFriendshipManager friendshipManager)
        {
            _userManager = userManager;
            _binaryObjectManager = binaryObjectManager;
            _appFolders = appFolders;
            _friendshipManager = friendshipManager;
        }

        public async Task<FileResult> GetProfilePicture()
        {
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
            if (user.ProfilePictureId == null)
            {
                return GetDefaultProfilePicture();
            }

            return await GetProfilePictureById(user.ProfilePictureId.Value);
        }

        public async Task<FileResult> GetProfilePictureById(string id = "")
        {
            if (id.IsNullOrEmpty())
            {
                return GetDefaultProfilePicture();
            }

            return await GetProfilePictureById(Guid.Parse(id));
        }

        [UnitOfWork]
        public virtual async Task<FileResult> GetFriendProfilePictureById(long userId, int? tenantId, string id = "")
        {
            if (id.IsNullOrEmpty() ||
                _friendshipManager.GetFriendshipOrNull(AbpSession.ToUserIdentifier(), new UserIdentifier(tenantId, userId)) == null)
            {
                return GetDefaultProfilePicture();
            }

            using (CurrentUnitOfWork.SetTenantId(tenantId))
            {
                return await GetProfilePictureById(Guid.Parse(id));
            }
        }

        public JsonResult UploadProfilePicture()
        {
            try
            {
                var profilePictureFile = Request.Form.Files.First();

                //Check input
                if (profilePictureFile == null)
                {
                    throw new UserFriendlyException(L("ProfilePicture_Change_Error"));
                }

                if (profilePictureFile.Length > 1048576) //1MB.
                {
                    throw new UserFriendlyException(L("ProfilePicture_Warn_SizeLimit"));
                }

                byte[] fileBytes;
                using (var stream = profilePictureFile.OpenReadStream())
                {
                    fileBytes = stream.GetAllBytes();
                }

                //Check file type & format
                using (var ms = new MemoryStream(fileBytes))
                {
                    var fileImage = Image.FromStream(ms);
                    var acceptedFormats = new List<ImageFormat>
                    {
                        ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif
                    };

                    if (!acceptedFormats.Contains(fileImage.RawFormat))
                    {
                        throw new ApplicationException("Uploaded file is not an accepted image file !");
                    }
                }

                //Delete old temp profile pictures
                AppFileHelper.DeleteFilesInFolderIfExists(_appFolders.TempFileDownloadFolder, "userProfileImage_" + AbpSession.GetUserId());

                //Save new picture
                var fileInfo = new FileInfo(profilePictureFile.FileName);
                var tempFileName = "userProfileImage_" + AbpSession.GetUserId() + fileInfo.Extension;
                var tempFilePath = Path.Combine(_appFolders.TempFileDownloadFolder, tempFileName);
                System.IO.File.WriteAllBytes(tempFilePath, fileBytes);

                using (var bmpImage = new Bitmap(tempFilePath))
                {
                    return Json(new AjaxResponse(new { fileName = tempFileName, width = bmpImage.Width, height = bmpImage.Height }));
                }
            }
            catch (UserFriendlyException ex)
            {
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        private FileResult GetDefaultProfilePicture()
        {
            return File(
                @"Common\Images\default-profile-picture.png",
                MimeTypeNames.ImagePng
            );
        }

        private async Task<FileResult> GetProfilePictureById(Guid profilePictureId)
        {
            var file = await _binaryObjectManager.GetOrNullAsync(profilePictureId);
            if (file == null)
            {
                return GetDefaultProfilePicture();
            }

            return File(file.Bytes, MimeTypeNames.ImageJpeg);
        }
    }
}