using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class SubscriptionClientTests
    {
        private readonly Client _client;

        public SubscriptionClientTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetEmailSubscriptionTest()
        {
            int? contactId = 44664;
            var result = _client.Data.ContactEmailSubscription.Get(contactId, "*", 1, 100);
            Assert.True(result.Count > 0);
        }
    }
}
