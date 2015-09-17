using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients
{
    public class GenericClient<T> where T : EloquaDto, ISearchable, new()
    {
        public GenericClient(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }
        readonly BaseClient _baseClient;

        public T Get(int id, Depth depth = Depth.Minimal)
        {
            return GetAsync(id, depth).Result;
        }

        public async Task<T> GetAsync(int id, Depth depth = Depth.Minimal)
        {
            var data = new T { Id = id, Depth = depth.ToString() };
            return await _baseClient.GetAsync(data);
        }

        public T Post(T data)
        {
            return PostAsync(data).Result;
        }

        public async Task<T> PostAsync(T data)
        {
            return await _baseClient.PostAsync(data);
        }

        public T Put(T data)
        {
            return PutAsync(data).Result;
        }

        public async Task<T> PutAsync(T data)
        {
            return await _baseClient.PutAsync(data);
        }

        public async Task DeleteAsync(int? id)
        {
            var data = new T { Id = id };
            await _baseClient.DeleteAsync(data);
        }

        public void Delete(int? id)
        {
            DeleteAsync(id).Wait();
        }

        public async Task<SearchResponse<T>> GetAsync(string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return await _baseClient.SearchAsync(new T
            {
                SearchTerm = search,
                Page = pageNumber,
                PageSize = pageSize,
                Depth = depth.ToString()
            });
        }

        public SearchResponse<T> Get(string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return GetAsync(search, pageNumber, pageSize, depth).Result;
        }

        public SearchResponse<T> Get(int? id, string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return GetAsync(id, search, pageNumber, pageSize, depth).Result;
        }

        public async Task<SearchResponse<T>> GetAsync(int? id, string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
        {
            return await _baseClient.SearchAsync(new T
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