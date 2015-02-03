using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Microsites;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class MicrositeClientTests
    {
        private readonly Client client;

        public MicrositeClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetMicrositeTest()
        {
            const int originalId = 8;
            var microsite = client.Assets.Microsite.Get(originalId);

            Assert.Equal(originalId, microsite.id);
        }

        [Fact]
        public void GetMicrositeListTest()
        {
            var result = client.Assets.Microsite.Get("*", 1, 1);
            Assert.Equal(1, result.elements.Count);
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
                    domains = new List<string> {"sample.com"},
                    isSecure = false
                };

                microsite = client.Assets.Microsite.Post(expectedMicrosite);
                Assert.Equal(expectedMicrosite.name, microsite.name);
            }
            finally
            {
                if (microsite != null && microsite.id > 0)
                {
                    client.Assets.Microsite.Delete(microsite.id);
                }
            }
        }
    }
}