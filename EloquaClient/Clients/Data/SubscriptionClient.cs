using RestSharp;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class SubscriptionClient
    {
        public SubscriptionClient(EloquaRestClient eloquaRestClient)
        {
            _eloquaRestClient = eloquaRestClient;
        }
        readonly EloquaRestClient _eloquaRestClient;

        public ContactEmailSubscription Get(int? contactId, int? emailGroupId)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                Resource = $"/data/contact/{contactId}/email/group/{emailGroupId}/subscription"
            };

            return _eloquaRestClient.ExecuteWithErrorHandling<ContactEmailSubscription>(request);
        }

        public List<ContactEmailSubscription> Get(int? contactId, string searchTerm, int page, int pageSize)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                RootElement = "elements",
                Resource = $"/data/contact/{contactId}/email/groups/subscription?search={searchTerm}&page={page}&count={pageSize}"
            };

            return _eloquaRestClient.ExecuteWithErrorHandling<List<ContactEmailSubscription>>(request);
        }
    }
}
