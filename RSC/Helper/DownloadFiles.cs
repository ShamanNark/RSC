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

        #region University 

        public async Task<int?> SaveEGRULFile(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/EGRUL/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        public async Task<int?> OrderApprovalRectorFile(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/Приказ об утверждении (назначении) ректора/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        #endregion

        #region CO

        public async Task<int?> SaveCoPrivateFile(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/CoPrivateFiles/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        public async Task<int?> SaveConferenceProtocol(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/Протокол отчетно-выборной конференции СО/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        public async Task<int?> SaveProtocolApprovalStudentAssociations(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/Протокол СО об утверждении/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        public async Task<int?> SaveOrderCreationCouncilOfLearners(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/Приказ о создании Совета обучающихся/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        #endregion

        #region AddImages 

        public async Task<int?> SaveEventPublicFoto(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/EventPublicFotos/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        public async Task<int?> SaveEventPublicSmallFotos(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/EventPublicSmallFotos/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        #endregion 

        public async Task<int?> SavePowerOfAttorney (IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/Доверенность/";
            return await AddFile(uploadedFile, folderPath, fileName);
        }

        public async Task<int?> SaveProfileImage(IFormFile uploadedFile, string fileName, string fullPathWithFormatFile)
        {
            var folderPath = "/files/Аватарки/";
            return await AddFile(uploadedFile, folderPath , fileName);
        }

        private async Task<int?> AddFile(IFormFile uploadedFile, string nameFolder, string fileName)
        {
            try
            {
                if (uploadedFile != null)
                {
                    string path = "";
                    int index = 0;
                    do
                    {
                        string name = Path.GetFileNameWithoutExtension(fileName);
                        path = _appEnvironment.WebRootPath + nameFolder + name + $"({index})" + Path.GetExtension(fileName).ToLowerInvariant();
                        index++;
                        var t =  File.Exists(path);
                    }
                    while(File.Exists(path));

                    char[] charsToTrim = { ' ', '\t'};
                    path = path.Trim(charsToTrim);
                    using (var fileStream = new FileStream(path, FileMode.CreateNew))
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

        //public async Task<int?> AddImages(IFormFile uploadedFile, string fileName, string oldFileNameWithFormat)
        //{
        //    try
        //    {
        //        if (uploadedFile != null)
        //        {
        //            string path = "/images/" + fileName + Path.GetExtension(oldFileNameWithFormat).ToLowerInvariant();
        //            char[] charsToTrim = { ' ', '\t' };
        //            path = path.Trim(charsToTrim);
        //            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
        //            {
        //                await uploadedFile.CopyToAsync(fileStream);
        //            }
        //            FileModel file = new FileModel { Name = fileName, Path = path };
        //            _context.Files.Add(file);
        //            _context.SaveChanges();
        //            return file.Id;
        //        }
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
