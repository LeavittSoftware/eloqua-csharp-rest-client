using Eloqua.Api.Rest.ClientLibrary.Models.Systems.Cloud;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Systems
{
    public class CloudDataClientTests
    {
        private readonly Client _client;

        public CloudDataClientTests()
        {
             _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetCloudDataTest()
        {
            var clouddata = new CloudDataInstance
            {
                Name = "sample",
                ProviderUrl = "www.test.com",
                IconUrl = "test",
                Description = "test"
            };

            var result = _client.Systems.CloudData.Post(clouddata);
            Assert.NotNull(result);
        }
    }
}