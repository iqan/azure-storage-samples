namespace AzureStorageSamples.UnitTests.Processor
{
    using AzureStorageSamples.Processor;
    using AzureStorageSamples.UnitTests.Fakes;
    using NUnit.Framework;

    [TestFixture]
    public class BlobProcessorShould
    {
        [Test]
        public void ReadFileFromBlobStorage()
        {
            var fakeBlobStorage = new FakeBlobStorage();

            fakeBlobStorage.DataToRead = "content";
            fakeBlobStorage.UploadComplete = true;

            var processor = new BlobStorageProcessor(fakeBlobStorage);
            processor.Process();
        }

        [Test]
        public void ThrowIfUploadFailed()
        {
            var error = "Failed to upload";
            var fakeBlobStorage = new FakeBlobStorage();

            fakeBlobStorage.DataToRead = "content";
            fakeBlobStorage.UploadComplete = false;

            var processor = new BlobStorageProcessor(fakeBlobStorage);
            var exception = Assert.Catch(() => processor.Process());
            Assert.That(exception.Message, Is.EqualTo(error));
        }
    }
}
