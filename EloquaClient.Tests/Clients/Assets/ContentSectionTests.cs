using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class ContentSectionTests
    {
        private readonly Client _client;

        public ContentSectionTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void SearchContentSectionTest()
        {
            var contentSections = _client.Assets.ContentSection.Get("*", 1, 100);
            Assert.True(contentSections.Total > 0);
        }

        [Fact]
        public void CreateContentSection()
        {
            var contentSection = new ContentSection
            {
                Id = -1,
                name = "sample content",
                Scope = Scope.Global.ToString(),
                ContentHtml = "<html><head></head><body>sample content</body></html>"
            };

            var returnedContentSection = _client.Assets.ContentSection.Post(contentSection);
            Assert.Equal(contentSection.name, returnedContentSection.name);
        }
    }
}
