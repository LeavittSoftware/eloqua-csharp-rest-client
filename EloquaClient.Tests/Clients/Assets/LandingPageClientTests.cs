using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class LandingPageClientTests
    {
        private readonly Client client;

        public LandingPageClientTests()
        {
            client = new Client("site", "username", "password", Constants.BaseUrl3);
        }

        [Fact]
        public void SearchLandingPageTest()
        {
            var landingPages = client.Assets.LandingPage.Get("id=9", 1, 100);
            Assert.True(landingPages.elements.Count > 0);
        }
    }
}
