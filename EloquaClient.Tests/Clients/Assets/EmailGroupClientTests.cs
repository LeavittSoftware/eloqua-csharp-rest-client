using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class EmailGroupClientTests
    {
        private readonly Client _client;

        public EmailGroupClientTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetEmailGroupTest()
        {
            const int emailGroupId = 8;
            var emailGroup = _client.Assets.EmailGroup.Get(emailGroupId);

            Assert.Equal(emailGroupId, emailGroup.Id);
        }

        [Fact]
        public void GetEmailGroupListTest()
        {
            var result = _client.Assets.EmailGroup.Get("*", 1, 100);
            Assert.Equal(1, result.Elements.Count);
        }
    }
}
