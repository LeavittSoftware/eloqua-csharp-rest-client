using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class SubscriptionClientTests
    {
        private readonly Client client;

        public SubscriptionClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetEmailSubscriptionTest()
        {
            int? contactId = 44664;
            var result = client.Data.ContactEmailSubscription.Get(contactId, "*", 1, 100);
            Assert.True(result.Count > 0);
        }
    }
}
