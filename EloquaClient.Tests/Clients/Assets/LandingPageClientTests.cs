using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class LandingPageClientTests
    {
        private readonly Client _client;

        public LandingPageClientTests()
        {
            _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl3));
        }

        [Fact]
        public void SearchLandingPageTest()
        {
            var landingPages = _client.Assets.LandingPage.Get("id=9", 1, 100);
            Assert.True(landingPages.Elements.Count > 0);
        }
    }
}
