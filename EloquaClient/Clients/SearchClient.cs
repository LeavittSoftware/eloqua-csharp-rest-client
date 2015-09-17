using LG.Eloqua.Api.Rest.ClientLibrary.Models;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients
{
    public class SearchClient<T> where T : EloquaDto, ISearchable, new()
    {
        public SearchClient(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }
        readonly BaseClient _baseClient;

        public SearchResponse<T> Get(string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return _baseClient.Search<T>(new T
            {
                SearchTerm = search,
                Page = pageNumber,
                PageSize = pageSize,
                Depth = depth.ToString()
            });
        }
    }
}