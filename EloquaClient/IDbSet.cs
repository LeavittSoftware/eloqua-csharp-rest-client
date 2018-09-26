using System.Collections.Generic;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public interface IDbSet<T> where T : IEloquaDataObject, new()
    {
        Task<T> GetAsync(int id, Depth depth = Depth.Minimal);
        Task<List<T>> SearchAsync(string searchTerm, int pageSize = 1000, int page = 1, Depth depth = Depth.Complete);

        Task<List<T>> GetListAsync(string orderBy = "", string searchTerm = "", int pageSize = 1000, int page = 1,
            Depth depth = Depth.Minimal);
        Task<T> PostAsync(T data);
        Task<T> PutAsync(T data);
    }
}