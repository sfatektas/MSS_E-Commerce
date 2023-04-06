using Azure.Storage.Blobs;
using E_Commerce.Business.Interfaces.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services.Storage
{
    public class AzureStorage : IStorage
    {
        readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient; // 
        public AzureStorage(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public (FileStream data, string imagetype) GetFile(string filepath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasData(string filename, string container)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFile(string fileorContainername)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadFile(string containername, IFormFile file)
        {
            try
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containername);
                await _blobContainerClient.CreateIfNotExistsAsync();
                await _blobContainerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

                var blobClient = _blobContainerClient.GetBlobClient(file.FileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                return true;
            }
            catch (Exception e)
            {

                throw new Exception($"Dosya yüklerken bir hata oluştu. Hata : {e.Message}");
            }
        }

        public async Task<bool> UploadFiles(string containername, List<IFormFile> files)
        {
            try
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containername);
                await _blobContainerClient.CreateIfNotExistsAsync();
                await _blobContainerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

                foreach (var file in files)
                {
                    var blobClient = _blobContainerClient.GetBlobClient(file.FileName);
                    await blobClient.UploadAsync(file.OpenReadStream());
                }
                return true;
            }
            catch (Exception e)
            {

                throw new Exception($"Dosya yüklerken bir hata oluştu. Hata : {e.Message}");
            }

        }
    }
}
