using System;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class EmailClientTests
    {
        private readonly Client _client;

        public EmailClientTests()
        {
             _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetEmailTest()
        {
            const int originalId = 8;
            var email = _client.Assets.Email.Get(originalId);

            Assert.Equal(originalId, email.Id);
        }

        [Fact]
        public void GetEmailListTest()
        {
            var result = _client.Assets.Email.Get("*", 1, 100);
            Assert.Equal(1, result.Elements.Count);
        }

        [Fact]
        public void PostEmailTest()
        {
            Email email = null;

            try
            {
                var expectedEmail = new Email
                                        {
                                            EmailGroupId = 1,
                                            name = string.Format("test-{0}", Guid.NewGuid())
                                        };

                email = _client.Assets.Email.Post(expectedEmail);
                Assert.Equal(expectedEmail.name, email.name);
            }
            finally
            {
                if (email != null && email.Id > 0)
                {
                    _client.Assets.Email.Delete(email.Id);
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
                                            EmailGroupId = 1,
                                            name = string.Format("test-{0}", Guid.NewGuid())
                                        };

                email = _client.Assets.Email.Post(expectedEmail);
                Assert.Equal(expectedEmail.name, email.name);

                string updatedName = string.Format("test-{0}", Guid.NewGuid());
                email.name = updatedName;
                email = _client.Assets.Email.Put(email);

                Assert.Equal(updatedName, email.name);
            }
            finally 
            {
                if (email != null && email.Id > 0)
                {
                    _client.Assets.Email.Delete(email.Id);
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
                                EmailGroupId = 1
                            };

            email = _client.Assets.Email.Post(email);
            _client.Assets.Email.Delete(email.Id);

            var result = _client.Assets.Email.Get(emailName, 1, 1);
            Assert.Equal(0, result.Elements.Count);
        }
    }
}