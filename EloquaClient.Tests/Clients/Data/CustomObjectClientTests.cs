using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class CustomObjectClientTests
    {
        private readonly Client client;

        public CustomObjectClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetCustomObjectTest()
        {
            const int originalId = 1;
            var customObject = client.Data.CustomObject.Get(originalId);

            Assert.Equal(originalId, customObject.id);
        }

        [Fact]
        public void SearchCustomObjectTest()
        {
            var result = client.Data.CustomObject.Get("*", 1, 1);
            Assert.Equal(1, result.elements.Count);
        }
    }
}
