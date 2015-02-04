using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Systems
{
    public class UserClientTests
    {
        private readonly Client client;

        public UserClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void SearchUsersTest()
        {
            var response = client.Systems.User.Get("*", 1, 10);
            Assert.True(response.total > 0);
        }

        [Fact]
        public void GetUserTest()
        {
            var response = client.Systems.User.Get(2, Depth.complete);
            Assert.NotNull(response);
        }
    }
}
