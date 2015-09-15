using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class ExternalAssetTests
    {
        private readonly Client _client;

        public ExternalAssetTests()
        {
             _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetExternalAssetsTest()
        {
            var response = _client.Assets.ExternalAsset.Get("*", 1, 10);
            Assert.True(response.Total > 0);
        }
    }
}
