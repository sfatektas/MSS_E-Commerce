using E_Commerce.Business.Interfaces.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services.Storage
{
    public class LocalStorage : IStorage
    {
        public Task<bool> HasData(string filename, string container)
        {
            throw new NotImplementedException();
        }
        public (FileStream data, string imagetype) GetFile(string filepath)
        {
            var isexist = File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filepath));
            if (isexist)
            {
                FileStream data = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filepath));
                string type = filepath.Substring(filepath.IndexOf('.') + 1);
                string contentType = type == "jpg" ? "jpeg" : type;
                return new(data, contentType);
            }
            throw new Exception("Dosyaya ulaşılamadı.");
        }
        public async Task<bool> UploadFile(string filename, IFormFile file)
        {
            try
            {
                FileStream fileStream = new(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", filename + Path.GetExtension(file.FileName)), FileMode.Create);
                await file.CopyToAsync(fileStream);
                fileStream.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception($"Sunucuya dosya yüklerken bir hata oluştu Hata : {e.Message}");
            }

        }

        public bool RemoveFile(string fileorContainername)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileorContainername);
            var isexist = File.Exists(path);
            if (!isexist)
                throw new FileNotFoundException("Silinecek dosya sunucuda bulunamdı");
            File.Delete(path);
            return true;
        }

        public async Task<bool> UploadFiles(string pathName, List<IFormFile> files)
        {
            throw new NotImplementedException();
            //try
            //{
            //    FileStream fileStream = new(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","files", pathName), FileMode.Create);
            //    foreach (var file in files)
            //    {
            //        await fileStream.CopyToAsync(file.OpenReadStream());
            //    }
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception($"Sunucuya dosya yüklerken bir hata oluştu Hata : {e.Message}");
            //}
        }

    }
}
