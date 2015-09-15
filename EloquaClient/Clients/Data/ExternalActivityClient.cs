using Eloqua.Api.Rest.ClientLibrary.Models.Data.ExternalActivities;
using RestSharp;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class ExternalActivityClient
    {
        public ExternalActivityClient(EloquaRestClient eloquaRestClient)
        {
            _eloquaRestClient = eloquaRestClient;
        }
        readonly EloquaRestClient _eloquaRestClient;

        public ExternalActivities Get(int? id)
        {
            var request = new RestRequest(Method.GET)
            {
                RequestFormat = DataFormat.Json,
                Resource = $"/data/activity/{id}"
            };

            return _eloquaRestClient.ExecuteWithErrorHandling<ExternalActivities>(request);
        }

        public ExternalActivities Post(ExternalActivities activities)
        {
            var request = new RestRequest(Method.POST)
            {
                RequestFormat = DataFormat.Json,
                Resource = "/data/activity"
            };

            request.AddBody(activities);
            return _eloquaRestClient.ExecuteWithErrorHandling<ExternalActivities>(request);
        }
    }
}
