using Eloqua.Api.Rest.ClientLibrary.Models;
using RestSharp;

namespace Eloqua.Api.Rest.ClientLibrary
{
    public interface IEloquaRestClient : IRestClient
    {
        T ExecuteWithErrorHandling<T>(IRestRequest request) where T : new();
        T Get<T>(T data) where T : RestObject, new();
        void Delete<T>(T data) where T : RestObject, new();
        T Post<T>(T data) where T : RestObject, new();
        T Put<T>(T data) where T : RestObject, new();
        SearchResponse<T> Search<T>(T data) where T : RestObject, ISearchable, new();
        SearchResponse<T> Search<T>(int id, T data) where T : RestObject, ISearchable, new();
    }
}