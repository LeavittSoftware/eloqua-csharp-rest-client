using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using static System.String;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class DbSet<T> : IDbSet<T> where T : IEloquaDataObject, new()
    {
        private readonly IRestClient _restClient;
        public DbSet(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<T> GetAsync(int id, Depth depth = Depth.Minimal)
        {
            if (!(Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) is Resource resourceAttribute))
                throw new DbSetException();

            var request = new RestRequest($"{resourceAttribute.RestApiPath}{resourceAttribute.Uri}/{{id}}", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddUrlSegment("id", id.ToString());

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaJsonSerializer.Deserializer<T>(response.Content);
        }

        public async Task<Element<T>> GetListAsync(string orderBy = "", string searchTerm = "", int pageSize = 1000, int page = 1, Depth depth = Depth.Minimal)
        {
            if (!(Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) is Resource resourceAttribute))
                throw new DbSetException();

            var request = new RestRequest($"{resourceAttribute.RestApiPath}{resourceAttribute.Uri}s", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddParameter("count", pageSize.ToString());
            request.AddParameter("page", page.ToString());
            if (!IsNullOrWhiteSpace(orderBy))
            {
                request.AddParameter("orderBy", orderBy);
            }
            if (!IsNullOrWhiteSpace(searchTerm))
            {
                request.AddParameter("search", searchTerm);
            }

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);
            return EloquaJsonSerializer.Deserializer<Element<T>>(response.Content);
        }

        public async Task<Element<T>> SearchAsync(string searchTerm, int pageSize = 1000, int page = 1,
            Depth depth = Depth.Complete)
        {
            if (!(Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) is Resource resourceAttribute))
                throw new DbSetException();

            var request = new RestRequest($"{resourceAttribute.RestApiPath}{resourceAttribute.Uri}s", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddParameter("count", pageSize.ToString());
            request.AddParameter("page", page.ToString());
            request.AddParameter("search", searchTerm);

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaJsonSerializer.Deserializer<Element<T>>(response.Content);
        }

        public async Task<T> PostAsync(T data)
        {
            if (!(Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) is Resource resourceAttribute))
                throw new DbSetException();

            dynamic requestObject = new JObject();
            requestObject.FieldValues = new JArray();
            requestObject.Type = resourceAttribute.Type;

            //Static Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var value = EloquaJsonSerializer.SerializeProperty(property, data);
                if (value == null)
                    continue;

                requestObject[property.Name] = value;
            }

            //Dynamic Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

                var value = EloquaJsonSerializer.SerializeProperty(property, data);
                if (value == null)
                    continue;

                dynamic fieldValue = new JObject();
                fieldValue.Id = attribute?.EloquaCustomFieldId;
                fieldValue.Value = value;

                requestObject.FieldValues.Add(fieldValue);
            }

            var customDataPostUrl = requestObject["Id"] == null ? "" : $"/{requestObject["Id"]}";
            var requestUrl = $"{resourceAttribute.RestApiPath}{resourceAttribute.Uri}{customDataPostUrl}";
            var request = new RestRequest(requestUrl, Method.POST);

            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()};
            var serialized = JsonConvert.SerializeObject(requestObject, settings);
            
            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaJsonSerializer.Deserializer<T>(response.Content);
        }
        public async Task<T> PutAsync(T data)
        {
            if (!(Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) is Resource resourceAttribute))
                throw new DbSetException();

            dynamic requestObject = new JObject();
            requestObject.FieldValues = new JArray();
            requestObject.Type = resourceAttribute.Type;

            //Static Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var value = EloquaJsonSerializer.SerializeProperty(property, data);
                if (value == null)
                    continue;

                requestObject[property.Name] = value;
            }

            //Dynamic Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

                var value = EloquaJsonSerializer.SerializeProperty(property, data);
                if (value == null)
                    continue;

                dynamic fieldValue = new JObject();
                fieldValue.Id = attribute?.EloquaCustomFieldId;
                fieldValue.Value = value;

                requestObject.FieldValues.Add(fieldValue);
            }

            var customDataPostUrl = requestObject["Id"] == null ? "" : $"/{requestObject["Id"]}";
            var requestUrl = $"{resourceAttribute.RestApiPath}{resourceAttribute.Uri}{customDataPostUrl}";
            var request = new RestRequest(requestUrl, Method.PUT);

            var jObject = JsonConvert.DeserializeObject<ExpandoObject>(requestObject.ToString());
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };
            var serialized = JsonConvert.SerializeObject(jObject, settings);

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaJsonSerializer.Deserializer<T>(response.Content);
        }

    }
}
