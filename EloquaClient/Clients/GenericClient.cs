using Eloqua.Api.Rest.ClientLibrary.Models;

namespace Eloqua.Api.Rest.ClientLibrary.Clients
{
    public class GenericClient<T> where T : RestObject, ISearchable, new()
    {
        public GenericClient(EloquaRestClient eloquaRestClient)
        {
            _eloquaRestClient = eloquaRestClient;
        }
        readonly EloquaRestClient _eloquaRestClient;

        public T Get(int id, Depth depth = Depth.Minimal)
        {
            var data = new T { Id = id, Depth = depth.ToString() };
            return _eloquaRestClient.Get(data);
        }

        public T Post(T data)
        {
            return _eloquaRestClient.Post(data);
        }

        public T Put(T data)
        {
            return _eloquaRestClient.Put(data);
        }

        public void Delete(int? id)
        {
            var data = new T { Id = id };
            _eloquaRestClient.Delete(data);
        }

        public SearchResponse<T> Get(string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return _eloquaRestClient.Search(new T
                {
                    SearchTerm = search,
                    Page = pageNumber,
                    PageSize = pageSize,
                    Depth = depth.ToString()
                });
        }

        public SearchResponse<T> Get(int? id, string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return _eloquaRestClient.Search(new T
                    {
                        Id = id,
                        SearchTerm = search,
                        Page = pageNumber,
                        PageSize = pageSize,
                        Depth = depth.ToString()
                    });
        }
    }
}