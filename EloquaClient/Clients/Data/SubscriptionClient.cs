using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class SubscriptionClient
    {
        public SubscriptionClient(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }
        readonly BaseClient _baseClient;

        public ContactEmailSubscription Get(int? contactId, int? emailGroupId)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                Resource = $"/data/contact/{contactId}/email/group/{emailGroupId}/subscription"
            };

            return _baseClient.Execute<ContactEmailSubscription>(request);
        }

        public List<ContactEmailSubscription> Get(int? contactId, string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                RootElement = "elements",
                Resource = $"/data/contact/{contactId}/email/groups/subscription?search={searchTerm}&page={page}&count={pageSize}"
            };

            return _baseClient.Execute<List<ContactEmailSubscription>>(request);
        }
    }
}
