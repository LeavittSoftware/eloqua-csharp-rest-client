using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class CustomObjectClientTests
    {
        private readonly Client _client;

        public CustomObjectClientTests()
        {
             _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetCustomObjectTest()
        {
            const int originalId = 1;
            var customObject = _client.Data.CustomObject.Get(originalId);

            Assert.Equal(originalId, customObject.Id);
        }

        [Fact]
        public void SearchCustomObjectTest()
        {
            var result = _client.Data.CustomObject.Get("*", 1, 1);
            Assert.Equal(1, result.Elements.Count);
        }
    }
}
