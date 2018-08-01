namespace AzureStorageSamples.Infrastructure.BlobStorage
{
    using System.IO;
    using System.Threading.Tasks;

    public class BlobStorage : IBlobStorage
    {
        private readonly BlobStorageConfig storageConfig;

        public BlobStorage(BlobStorageConfig storageConfig)
        {
            this.storageConfig = storageConfig;
        }

        public Task<string> ReadFileAsStringAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UploadFileAsync(Stream fileStream, string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}
