using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views;
using RestSharp;
using RestSharp.Deserializers;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class ContactFieldTests
    {
        private readonly Client _client;

        public ContactFieldTests()
        {
            _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void SearchContactFields()
        {
            var fields = _client.Assets.ContactFields.Get("*", 1, 100);
            Assert.True(fields.Total > 0);
        }

        [Fact]
        public void CreateContactField()
        {
            var field = new ContactField { name = "V_Notes", DataType = "largeText", UpdateType = "always", DisplayType = "text" };
            field = _client.Assets.ContactFields.Post(field);
            Assert.NotNull(field.Id);
        }
    }
}
