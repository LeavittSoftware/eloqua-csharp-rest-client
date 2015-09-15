using Eloqua.Api.Rest.ClientLibrary.Models.Data.ExternalActivities;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class ExternalActivityClientTests
    {
        private readonly Client _client;

        public ExternalActivityClientTests()
        {
             _client = new Client(new BaseClient("sites", "user", "password", Constants.BaseUrl));
        }

        [Fact]
        public void GetActivityTest()
        {
            var response = _client.Data.ExternalActivity.Get(1);
            Assert.NotNull(response);
        }

        [Fact]
        public void CreateAndReadActivityTest()
        {
            var activity = new Activity();

            var externalActivities = new ExternalActivities
            {
                ActivityDate = "1362543780",
                ActivityType = "Webinar",
                AssetName = "TEST_GENERIC_Asset",
                AssetType = "Test_Generic_Asset_Type",
                ContactId = "100",
                CampaignId = "4",
                Type = "ExternalActivities"
            };

            var postExternalActivities = _client.Data.ExternalActivity.Post(externalActivities);
            var returnExternalActivities = _client.Data.ExternalActivity.Get(int.Parse(postExternalActivities.ContactId));

            Assert.NotNull(returnExternalActivities);
        }
    }
}
