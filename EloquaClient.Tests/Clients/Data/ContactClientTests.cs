using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class ContactClientTests
    {
        private readonly Client client;

        public ContactClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetContactTest()
        {
            const int originalId = 1;
            var contact = client.Data.Contact.Get(originalId);

            Assert.Equal(originalId, contact.id);
        }

        [Fact]
        public void SearchContactTest()
        {
            var result = client.Data.Contact.Get("*", 1, 1);
            Assert.Equal(1, result.elements.Count);
        }

        [Fact]
        public void CreateContactTest()
        {
            var contact = new Contact
            {
                id = -500002,
                firstName = "sample",
                lastName = "test",
                emailAddress = "sample@test.com"
            };

            var returnedContact = client.Data.Contact.Post(contact);

            Assert.Equal(contact.emailAddress, returnedContact.emailAddress);
        }
    }
}
