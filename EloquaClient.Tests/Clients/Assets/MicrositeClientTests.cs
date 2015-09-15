using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Microsites;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class MicrositeClientTests
    {
        private readonly Client _client;

        public MicrositeClientTests()
        {
             _client = new Client(new EloquaRestClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetMicrositeTest()
        {
            const int originalId = 8;
            var microsite = _client.Assets.Microsite.Get(originalId);

            Assert.Equal(originalId, microsite.Id);
        }

        [Fact]
        public void GetMicrositeListTest()
        {
            var result = _client.Assets.Microsite.Get("*", 1, 1);
            Assert.Equal(1, result.Elements.Count);
        }

        [Fact]
        public void PostMicrositeTest()
        {
            Microsite microsite = null;

            try
            {
                var expectedMicrosite = new Microsite
                {
                    name = "sample",
                    Domains = new List<string> {"sample.com"},
                    IsSecure = false
                };

                microsite = _client.Assets.Microsite.Post(expectedMicrosite);
                Assert.Equal(expectedMicrosite.name, microsite.name);
            }
            finally
            {
                if (microsite != null && microsite.Id > 0)
                {
                    _client.Assets.Microsite.Delete(microsite.Id);
                }
            }
        }
    }
}