using Azure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Interfaces.Storage
{
    public interface IStorage
    {
        public Task<bool> HasData(string filename, string container);
        (FileStream data, string imagetype) GetFile(string filepath);
        public Task<bool> UploadFiles(string containername, List<IFormFile> files);
        public Task<bool> UploadFile(string containername, IFormFile file);
    }
}
