namespace AzureStorageSamples.Infrastructure.BlobStorage
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IBlobStorage : IStorage
    {
        Task<string> ReadFileAsStringAsync();

        Task<bool> UploadFileAsync(Stream fileStream, string fileName);
    }
}
