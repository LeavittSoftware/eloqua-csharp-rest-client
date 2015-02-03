using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class ExternalAssetTests
    {
        private readonly Client client;

        public ExternalAssetTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetExternalAssetsTest()
        {
            var response = client.Assets.ExternalAsset.Get("*", 1, 10);
            Assert.True(response.total > 0);
        }
    }
}
