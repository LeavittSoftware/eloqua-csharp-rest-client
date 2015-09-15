using Eloqua.Api.Rest.ClientLibrary.Models;

namespace Eloqua.Api.Rest.ClientLibrary.Clients
{
    public class SearchMembersClient<T> where T : RestObject, ISearchable, new()
    {
        public SearchMembersClient(EloquaRestClient eloquaRestClient)
        {
            _eloquaRestClient = eloquaRestClient;
        }
        readonly EloquaRestClient _eloquaRestClient;

        public SearchResponse<T> Get(int? id, string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return _eloquaRestClient.Search<T>(new T
            {
                SearchTerm = search,
                Page = pageNumber,
                PageSize = pageSize,
                Depth = depth.ToString()
            });
        }
    }
}