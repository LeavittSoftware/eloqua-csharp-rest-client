using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Campaigns;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class CampaignTests
    {
        private readonly Client client;

        public CampaignTests()
        {
            client = new Client("site", "user", "pass", Constants.BaseUrl);
        }

        [Fact]
        public void SearchContactFields()
        {
            SearchResponse<Campaign> fields;
            
            var page = 1;

            do
            {
                fields = client.Assets.Campaign.Get("*", page, 300, Depth.partial);
                page++;

            } while (fields.elements.Count == 300);

            Assert.NotEqual(fields.total, 0);
        }

    }
}
