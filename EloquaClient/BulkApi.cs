using System;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
using Newtonsoft.Json;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class BulkApi : IBulkApi
    {
        protected IRestClient RestClient { get; }
        public BulkApi(IRestClient restClient)
        {
            RestClient = restClient;
        }

        private const string BulkApiPath = "/api/bulk/2.0/";

        public async Task<DateTime?> CreateCustomObjectDataAsync<T>(int importId, T customObjectData) where T : IEloquaDataObject
        {
            //EloquaCustomObjectAttribute
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(EloquaCustomObjectAttribute)) as EloquaCustomObjectAttribute;
            if (resourceAttribute == null)
                throw new DbSetException();

            var requestUrl = $"{BulkApiPath}customObjects/{resourceAttribute.CustomObjectId}/imports/{importId}/data";
            var request = new RestRequest(requestUrl, Method.POST);

            var serialized = JsonConvert.SerializeObject(customObjectData, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await RestClient.ExecuteTaskAsync(request);
            EloquaResponseHandler.ErrorCheck(response);

            var responseObject = JsonConvert.DeserializeObject<JsonObject>(response.Content);

            if (responseObject.ContainsKey("createdAt"))
                return (DateTime?)responseObject["createdAt"];

            return null;
        }
    }

}
