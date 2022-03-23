using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface IUploadFile
    {
        string UploadFileFunc(IEnumerable<IFormFile> files, string uploadPath);
        string UploadAttachFileFunc(IEnumerable<IFormFile> files, string uploadPath, string username);
    }
}
