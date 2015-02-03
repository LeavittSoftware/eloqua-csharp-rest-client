using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class FormClientTests
    {
        private readonly Client client;

        public FormClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetFormDataTest()
        {
            var data = client.Data.FormData.Get(1);
            Assert.True(data.fieldValues.Count > 0);
        }
    }
}
