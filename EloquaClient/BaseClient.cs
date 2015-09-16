using System;
using System.Threading.Tasks;
using Eloqua.Api.Rest.ClientLibrary.Exceptions;
using RestSharp;
using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Validation;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace Eloqua.Api.Rest.ClientLibrary
{
    public sealed class BaseClient
    {
        public IRestClient RestClient
        {
            get; private set;
        }

        public BaseClient(IRestClient restClient)
        {
            RestClient = restClient;
        }

        public BaseClient(string site, string username, string password, Uri baseUri)
        {
            var restClient = new RestClient
            {
                BaseUrl = baseUri,
                Authenticator = new HttpBasicAuthenticator(site + "\\" + username, password)
            };
            restClient.AddHandler("text/plain", new JsonDeserializer());
            RestClient = restClient;
        }

        public async Task<T> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            var response = await RestClient.ExecuteTaskAsync<T>(request);

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Completed:
                    return response.Data;
                case ResponseStatus.Aborted:
                case ResponseStatus.TimedOut:
                    throw new ConnectionErrorException(response);
                default:
                    throw ResponseValidator.GetExceptionFromResponse(response);
            }
        }

        public T Execute<T>(IRestRequest request) where T : new()
        {
            return ExecuteAsync<T>(request).Result;
        }

        public async Task<T> GetAsync<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Get, data);
            return await ExecuteAsync<T>(request);
        }

        public T Get<T>(T data) where T : RestObject, new()
        {
            return GetAsync(data).Result;
        }

        public void Delete<T>(T data) where T : RestObject, new()
        {
            DeleteAsync(data).Wait();
        }

        public async Task DeleteAsync<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Delete, data);
            await ExecuteAsync<T>(request);
        }

        public T Post<T>(T data) where T : RestObject, new()
        {
            return PostAsync(data).Result;
        }

        public async Task<T> PostAsync<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Post, data);
            return await ExecuteAsync<T>(request);
        }
        public T Put<T>(T data) where T : RestObject, new()
        {
            return PutAsync(data).Result;
        }

        public async Task<T> PutAsync<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Put, data);
            return await ExecuteAsync<T>(request);
        }

        public async Task<SearchResponse<T>> SearchAsync<T>(T data) where T : RestObject, ISearchable, new()
        {
            var request = Request.Get(Request.Type.Search, data);
            return await ExecuteAsync<SearchResponse<T>>(request);
        }

        public SearchResponse<T> Search<T>(T data) where T : RestObject, ISearchable, new()
        {
            return SearchAsync(data).Result;
        }

        public async Task<SearchResponse<T>> SearchAsync<T>(int id, T data) where T : RestObject, ISearchable, new()
        {
            var request = Request.Get(Request.Type.Search, data);
            return await ExecuteAsync<SearchResponse<T>>(request);
        }

        public SearchResponse<T> Search<T>(int id, T data) where T : RestObject, ISearchable, new()
        {
            return SearchAsync(id, data).Result;
        }
    }
}