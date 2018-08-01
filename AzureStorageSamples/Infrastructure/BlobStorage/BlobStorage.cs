namespace AzureStorageSamples.Infrastructure.BlobStorage
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BlobStorage : IBlobStorage
    {
        private readonly BlobStorageConfig storageConfig;

        public BlobStorage(BlobStorageConfig storageConfig)
        {
            this.storageConfig = storageConfig;
        }

        public async Task<string> ReadFileAsStringAsync()
        {
            var container = GetContainer();

            // Get the earliest uploaded block blob from the container
            var blockBlob = container.ListBlobs()
                .OfType<CloudBlockBlob>()
                .OrderBy(m => m.Properties.LastModified)
                .FirstOrDefault();

            if (blockBlob == null)
                return string.Empty;

            // Upload the file
            using (var memoryStream = new MemoryStream())
            {
                await blockBlob.DownloadToStreamAsync(memoryStream);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public async Task<bool> UploadFileAsync(Stream fileStream, string fileName)
        {
            var container = GetContainer();

            // Get the reference to the block blob from the container
            var blockBlob = container.GetBlockBlobReference(fileName);

            // Upload the file
            await blockBlob.UploadFromStreamAsync(fileStream);

            return await Task.FromResult(true);
        }

        private CloudBlobContainer GetContainer()
        {
            // Create cloudstorage account by passing the connectionString
            var storageAccount = CloudStorageAccount.Parse(this.storageConfig.ConnectionString);

            // Create the blob client.
            var blobClient = storageAccount.CreateCloudBlobClient();

            // Get container
            return blobClient.GetContainerReference(this.storageConfig.Container);
        }
    }
}
