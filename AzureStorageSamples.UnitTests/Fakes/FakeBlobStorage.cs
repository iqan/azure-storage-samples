namespace AzureStorageSamples.UnitTests.Fakes
{
    using System.IO;
    using System.Threading.Tasks;
    using AzureStorageSamples.Infrastructure.BlobStorage;

    internal class FakeBlobStorage : IBlobStorage
    {
        public string DataToRead { get; set; }

        public bool UploadComplete { get; set; }

        public Task<string> ReadFileAsStringAsync()
        {
            return Task.FromResult(DataToRead);
        }

        public Task<bool> UploadFileAsync(Stream fileStream, string fileName)
        {
            return Task.FromResult(UploadComplete);
        }
    }
}
