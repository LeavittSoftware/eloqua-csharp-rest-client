using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class DynamicContentTests
    {
        private readonly Client _client;

        public DynamicContentTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void SearchContentSectionTest()
        {
            var dynamicContents = _client.Assets.DynamicContent.Get("*", 1, 100);
            Assert.True(dynamicContents.Total > 0);
        }
    }
}
