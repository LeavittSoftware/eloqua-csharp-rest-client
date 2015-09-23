using System;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public interface IBulkApi
    {
        Task<DateTime?> CreateCustomObjectDataAsync<T>(int importId, T customObjectData) where T : CustomObjectData;
    }
}