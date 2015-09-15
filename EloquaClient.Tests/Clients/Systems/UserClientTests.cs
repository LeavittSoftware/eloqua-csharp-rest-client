using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Systems
{
    public class UserClientTests
    {
        private readonly Client _client;

        public UserClientTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void SearchUsersTest()
        {
            var response = _client.Systems.User.Get("*", 1, 10);
            Assert.True(response.Total > 0);
        }

        [Fact]
        public void GetUserTest()
        {
            var response = _client.Systems.User.Get(2, Depth.Complete);
            Assert.NotNull(response);
        }
    }
}
