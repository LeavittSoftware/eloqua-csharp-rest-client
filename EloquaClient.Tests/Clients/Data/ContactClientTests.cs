using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class ContactClientTests
    {
        private readonly Client _client;

        public ContactClientTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetContactTest()
        {
            const int originalId = 1;
            var contact = _client.Data.Contact.Get(originalId);

            Assert.Equal(originalId, contact.Id);
        }

        [Fact]
        public void SearchContactTest()
        {
            var result = _client.Data.Contact.Get("*", 1, 1);
            Assert.Equal(1, result.Elements.Count);
        }

        [Fact]
        public void CreateContactTest()
        {
            var contact = new Contact
            {
                Id = -500002,
                FirstName = "sample",
                LastName = "test",
                EmailAddress = "sample@test.com"
            };

            var returnedContact = _client.Data.Contact.Post(contact);

            Assert.Equal(contact.EmailAddress, returnedContact.EmailAddress);
        }
    }
}
