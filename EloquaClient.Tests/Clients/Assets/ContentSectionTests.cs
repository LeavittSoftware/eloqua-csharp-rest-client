using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class ContentSectionTests
    {
        private readonly Client client;

        public ContentSectionTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void SearchContentSectionTest()
        {
            var contentSections = client.Assets.ContentSection.Get("*", 1, 100);
            Assert.True(contentSections.total > 0);
        }

        [Fact]
        public void CreateContentSection()
        {
            var contentSection = new ContentSection
            {
                id = -1,
                name = "sample content",
                scope = Scope.global.ToString(),
                contentHtml = "<html><head></head><body>sample content</body></html>"
            };

            var returnedContentSection = client.Assets.ContentSection.Post(contentSection);
            Assert.Equal(contentSection.name, returnedContentSection.name);
        }
    }
}
