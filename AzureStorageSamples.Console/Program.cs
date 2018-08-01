namespace AzureStorageSamples.Console
{
    using AzureStorageSamples.Infrastructure.BlobStorage;
    using AzureStorageSamples.Processor;
    using System;
    using System.Configuration;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var blobConfig = new BlobStorageConfig
                {
                    ConnectionString = ConfigurationManager.AppSettings["BlobStorageConnectionString"],
                    Container = ConfigurationManager.AppSettings["BlobContainerName"]
                };
                var blobStorage = new BlobStorage(blobConfig);
                var processor = new BlobStorageProcessor(blobStorage);
                processor.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
