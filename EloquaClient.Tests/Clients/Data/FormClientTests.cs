using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class FormClientTests
    {
        private readonly Client _client;

        public FormClientTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetFormDataTest()
        {
            var data = _client.Data.FormData.Get(1);
            Assert.True(data.FieldValues.Count > 0);
        }
    }
}
