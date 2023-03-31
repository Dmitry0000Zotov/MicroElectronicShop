using MicroElectronic.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroElectronic.Service.Implementations
{
    public class BufferedFileUploadService : IBufferedFileUploadService
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            Guid guid = Guid.NewGuid();
            try
            {
                if (file.Length > 0)
                {
                    var extension = Path.GetExtension(file.FileName).ToString();
                    string path = Path.GetFullPath(Path.Combine("\\repos\\MicroElectronic\\MicroElectronic\\wwwroot\\lib\\images\\", "uploaded"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using(var fileStream = new FileStream(Path.Combine(path, "image_" + guid.ToString() + extension), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    string fullPath = "/lib/images/uploaded" + "/image_" + guid.ToString() + extension;
                    return fullPath;
                }
                else
                {
                    return "/lib/images/empty_picture.png";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File copy failed", ex);
            }
        }
    }
}
