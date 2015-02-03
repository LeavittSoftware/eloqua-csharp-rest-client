using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class DynamicContentTests
    {
        private readonly Client client;

        public DynamicContentTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void SearchContentSectionTest()
        {
            var dynamicContents = client.Assets.DynamicContent.Get("*", 1, 100);
            Assert.True(dynamicContents.total > 0);
        }
    }
}
