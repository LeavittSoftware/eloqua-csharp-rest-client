using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Campaigns;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    public class CampaignTests
    {
        private readonly Client _client;

        public CampaignTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void SearchContactFields()
        {
            SearchResponse<Campaign> fields;
            
            var page = 1;

            do
            {
                fields = _client.Assets.Campaign.Get("*", page, 300, Depth.Partial);
                page++;

            } while (fields.Elements.Count == 300);

            Assert.NotEqual(fields.Total, 0);
        }

    }
}
