using Eloqua.Api.Rest.ClientLibrary.Models.Data.ExternalActivities;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class ExternalActivityClientTests
    {
        private readonly Client client;

        public ExternalActivityClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        [Fact]
        public void GetActivityTest()
        {
            var response = client.Data.ExternalActivity.Get(1);
            Assert.NotNull(response);
        }

        [Fact]
        public void CreateAndReadActivityTest()
        {
            var activity = new Activity();

            var externalActivities = new ExternalActivities
            {
                activityDate = "1362543780",
                activityType = "Webinar",
                assetName = "TEST_GENERIC_Asset",
                assetType = "Test_Generic_Asset_Type",
                contactId = "100",
                campaignId = "4",
                type = "ExternalActivities"
            };

            var postExternalActivities = client.Data.ExternalActivity.Post(externalActivities);
            var returnExternalActivities = client.Data.ExternalActivity.Get(int.Parse(postExternalActivities.contactId));

            Assert.NotNull(returnExternalActivities);
        }
    }
}
