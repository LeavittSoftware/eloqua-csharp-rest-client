using Eloqua.Api.Rest.ClientLibrary.Models.Systems.Cloud;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Systems
{
    public class CloudDataClientTests
    {
        private readonly Client client;

        public CloudDataClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetCloudDataTest()
        {
            var clouddata = new CloudDataInstance
            {
                Name = "sample",
                ProviderURL = "www.test.com",
                IconURL = "test",
                Description = "test"
            };

            var result = client.Systems.CloudData.Post(clouddata);
            Assert.NotNull(result);
        }
    }
}