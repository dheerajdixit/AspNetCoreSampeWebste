using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace PhotoManager.Services
{
    public interface  IBlobService
    {
        Task<string> UploadBlobAsync(string blobName, Stream imageStream);
    }

    public class AzureBlobService : IBlobService
    {
        IConfiguration config;
        string containerName;

        public AzureBlobService(IConfiguration configuration)
        {
            config = configuration;
            containerName = config[Constants.KEY_BLOB];
        }

        public async Task<string> UploadBlobAsync(string blobName, Stream stream)
        {
            var containerClient = new BlobContainerClient(config[Constants.AZ_STORAGE_CNN], containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync( stream, new BlobHttpHeaders
                {
                 ContentType="images/jpeg",
                  CacheControl = "public"
            });
            return blobClient.Uri.ToString();

        }


    }
}


