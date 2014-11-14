using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Campaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactField = Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views.ContactField;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Assets
{
    [TestClass]
    public class CampaignTests
    {
        private Client _client;

        [TestInitialize]
        public void Init()
        {
            _client = new Client("site", "user", "pass", Constants.BaseUrl);
        }

        [TestMethod]
        public void SearchContactFields()
        {
            SearchResponse<Campaign> fields;
            
            int page = 1;
            do
            {
                fields = _client.Assets.Campaign.Get("*", page, 300, Depth.partial);
                page++;

            } while (fields.elements.Count == 300);
            Assert.AreNotEqual(fields.total, 0);
        }

    }
}
