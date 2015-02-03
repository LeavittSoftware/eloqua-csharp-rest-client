using System;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class EmailClientTests
    {
        private readonly Client client;

        public EmailClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetEmailTest()
        {
            const int originalId = 8;
            var email = client.Assets.Email.Get(originalId);

            Assert.Equal(originalId, email.id);
        }

        [Fact]
        public void GetEmailListTest()
        {
            var result = client.Assets.Email.Get("*", 1, 100);
            Assert.Equal(1, result.elements.Count);
        }

        [Fact]
        public void PostEmailTest()
        {
            Email email = null;

            try
            {
                var expectedEmail = new Email
                                        {
                                            emailGroupId = 1,
                                            name = string.Format("test-{0}", Guid.NewGuid())
                                        };

                email = client.Assets.Email.Post(expectedEmail);
                Assert.Equal(expectedEmail.name, email.name);
            }
            finally
            {
                if (email != null && email.id > 0)
                {
                    client.Assets.Email.Delete(email.id);
                }
            }
        }

        [Fact]
        public void PutEmailTest()
        {
            Email email = null;

            try
            {
                var expectedEmail = new Email()
                                        {
                                            emailGroupId = 1,
                                            name = string.Format("test-{0}", Guid.NewGuid())
                                        };

                email = client.Assets.Email.Post(expectedEmail);
                Assert.Equal(expectedEmail.name, email.name);

                string updatedName = string.Format("test-{0}", Guid.NewGuid());
                email.name = updatedName;
                email = client.Assets.Email.Put(email);

                Assert.Equal(updatedName, email.name);
            }
            finally 
            {
                if (email != null && email.id > 0)
                {
                    client.Assets.Email.Delete(email.id);
                }
            }
        }

        [Fact]
        public void DeleteEmailTest()
        {
            var emailName = Guid.NewGuid().ToString();
            var email = new Email
                            {
                                name = emailName,
                                emailGroupId = 1
                            };

            email = client.Assets.Email.Post(email);
            client.Assets.Email.Delete(email.id);

            var result = client.Assets.Email.Get(emailName, 1, 1);
            Assert.Equal(0, result.elements.Count);
        }
    }
}