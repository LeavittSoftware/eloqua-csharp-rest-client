using System;
using Eloqua.Api.Rest.ClientLibrary.Exceptions;
using RestSharp;
using Eloqua.Api.Rest.ClientLibrary.Models;
using Eloqua.Api.Rest.ClientLibrary.Validation;
using RestSharp.Deserializers;

namespace Eloqua.Api.Rest.ClientLibrary
{
    public sealed class EloquaRestClient
    {
        public IRestClient RestClient
        {
            get; private
            set;
        }

        public EloquaRestClient(IRestClient restClient)
        {
            RestClient = restClient;
        }

        public EloquaRestClient(string site, string username, string password, Uri baseUri)
        {
            var restClient = new RestClient
            {
                BaseUrl = baseUri,
                Authenticator = new HttpBasicAuthenticator(site + "\\" + username, password)
            };
            restClient.AddHandler("text/plain", new JsonDeserializer());
            RestClient = restClient;
        }

        public T ExecuteWithErrorHandling<T>(IRestRequest request) where T : new()
        {
            var response = RestClient.Execute<T>(request);

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

        public T Get<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Get, data);
            return ExecuteWithErrorHandling<T>(request);
        }

        public void Delete<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Delete, data);
            ExecuteWithErrorHandling<T>(request);
        }

        public T Post<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Post, data);
            return ExecuteWithErrorHandling<T>(request);
        }

        public T Put<T>(T data) where T : RestObject, new()
        {
            var request = Request.Get(Request.Type.Put, data);
            return ExecuteWithErrorHandling<T>(request);
        }

        public SearchResponse<T> Search<T>(T data) where T : RestObject, ISearchable, new()
        {
            var request = Request.Get(Request.Type.Search, data);
            return ExecuteWithErrorHandling<SearchResponse<T>>(request);
        }

        public SearchResponse<T> Search<T>(int id, T data) where T : RestObject, ISearchable, new()
        {
            var request = Request.Get(Request.Type.Search, data);
            return ExecuteWithErrorHandling<SearchResponse<T>>(request);
        }
    }
}