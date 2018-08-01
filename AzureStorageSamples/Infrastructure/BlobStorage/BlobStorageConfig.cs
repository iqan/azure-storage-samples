namespace AzureStorageSamples.Infrastructure.BlobStorage
{
    public class BlobStorageConfig : AzureStorageConfig
    {
        public string Container { get; set; }

        public string Blob { get; set; }
    }
}
