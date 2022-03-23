using BusinessProject.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BusinessProject.Core.Classes
{
   public class UploadFile : IUploadFile
    {
        private readonly IHostingEnvironment _appEnvironment;

        public UploadFile(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public string UploadFileFunc(IEnumerable<IFormFile> files, string uploadPath)
        {
            var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
            var filename = "";
            foreach (var item in files)
            {
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(item.FileName);
                using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    item.CopyTo(fs);
                }
            }
            return filename;
        }

        public string UploadAttachFileFunc(IEnumerable<IFormFile> files, string uploadPath, string username)
        {
            var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
            if (!Directory.Exists(upload + username))
            {
                Directory.CreateDirectory(upload + username);
            }
            upload = upload + username;

            var filename = "";
            foreach (var item in files)
            {
                filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(item.FileName);
                using (var fs = new FileStream(Path.Combine(upload, filename), FileMode.Create))
                {
                    item.CopyTo(fs);
                }
            }
            return filename;
        }
    }
}
