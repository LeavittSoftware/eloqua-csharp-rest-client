using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients
{
    public class AccountInfoTests
    {
        [Fact]
        public void SearchContentSectionTest()
        {
            var accountInfo = Client.GetAccountInfo("site", "user", "password");
            Assert.NotNull(accountInfo);
        }
    }
}