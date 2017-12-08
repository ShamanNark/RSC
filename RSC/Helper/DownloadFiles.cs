using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RSC.Data;
using RSC.Data.DbModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RSC.Helper
{
    public class DownloadFiles
    {

        ApplicationDbContext _context;
        IHostingEnvironment _appEnvironment;

        public DownloadFiles(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task<int?> AddFile(IFormFile uploadedFile, string fileName, string oldFileNameWithFormat)
        {
            try
            {
                if (uploadedFile != null)
                {
                    string path = "/files/" + fileName + Path.GetExtension(oldFileNameWithFormat).ToLowerInvariant();
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    FileModel file = new FileModel { Name = fileName, Path = path };
                    _context.Files.Add(file);
                    _context.SaveChanges();
                    return file.Id;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int?> AddImages(IFormFile uploadedFile, string fileName, string oldFileNameWithFormat)
        {
            try
            {
                if (uploadedFile != null)
                {
                    string path = "/images/" + fileName + Path.GetExtension(oldFileNameWithFormat).ToLowerInvariant();
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    FileModel file = new FileModel { Name = fileName, Path = path };
                    _context.Files.Add(file);
                    _context.SaveChanges();
                    return file.Id;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
