namespace AzureStorageSamples.Processor
{
    using AzureStorageSamples.Infrastructure.BlobStorage;
    using System.IO;

    public class BlobStorageProcessor : IProcessor
    {
        private readonly IBlobStorage blobStorage;

        public BlobStorageProcessor(IBlobStorage blobStorage)
        {
            this.blobStorage = blobStorage;
        }

        public void Process()
        {
            var data = this.blobStorage.ReadFileAsStringAsync().Result;
            var streamToUpload = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(data));
            var fileName = "file1";
            var result = this.blobStorage.UploadFileAsync(streamToUpload, fileName).Result;
            if (!result)
            {
                throw new System.Exception("Failed to upload");
            }
        }
    }
}
