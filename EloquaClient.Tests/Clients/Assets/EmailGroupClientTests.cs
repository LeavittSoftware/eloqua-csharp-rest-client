using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class EmailGroupClientTests
    {
        private readonly Client client;

        public EmailGroupClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetEmailGroupTest()
        {
            const int emailGroupId = 8;
            var emailGroup = client.Assets.EmailGroup.Get(emailGroupId);

            Assert.Equal(emailGroupId, emailGroup.id);
        }

        [Fact]
        public void GetEmailGroupListTest()
        {
            var result = client.Assets.EmailGroup.Get("*", 1, 100);
            Assert.Equal(1, result.elements.Count);
        }
    }
}
