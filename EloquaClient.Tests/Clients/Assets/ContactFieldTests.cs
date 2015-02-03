using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class ContactFieldTests
    {
        private readonly Client client;

        public ContactFieldTests()
        {
            client = new Client("sites", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void SearchContactFields()
        {
            var fields = client.Assets.ContactFields.Get("*", 1, 100);
            Assert.True(fields.total > 0);
        }

        [Fact]
        public void CreateContactField()
        {
            var field = new ContactField { name = "V_Notes", dataType = "largeText", updateType = "always", displayType = "text" };
            field = client.Assets.ContactFields.Post(field);
            Assert.NotNull(field.id);
        }
    }
}
