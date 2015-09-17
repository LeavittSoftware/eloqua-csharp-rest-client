using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;

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
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new Exception("Connot determine the endpoint");

            var request = new RestRequest($"{resourceAttribute.Uri}/{{id}}", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddUrlSegment("id", id.ToString());

            var response = await ExecuteWithErrorCheckAsync(request);

            return ConvertToConcreateClass(response.Content);
        }
        public async Task<List<T>> SearchAsync(string searchTerm, int pageSize = 1000, int page = 1, Depth depth = Depth.Complete)
        {
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new Exception("Connot determine the endpoint");

            var request = new RestRequest($"{resourceAttribute.Uri}s", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddParameter("count", pageSize.ToString());
            request.AddParameter("page", page.ToString());
            request.AddParameter("search", searchTerm);

            var response = await ExecuteWithErrorCheckAsync(request);

            var searchObject = JObject.Parse(response.Content);

            var elements = searchObject["elements"] as JArray;
            return elements?.Select(o => ConvertToConcreateClass(o.ToString())).ToList() ?? new List<T>();
        }
        public async Task<T> PostAsync(T data)
        {
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new Exception("Connot determine the endpoint");

            dynamic requestObject = new JObject();
            requestObject.FieldValues = new JArray();
            requestObject.Type = resourceAttribute.Type;

            //Static Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var value = property.GetValue(data);
                string asString = null;
                if (value != null)
                    asString = value.ToString();
                requestObject[property.Name] = asString;
            }

            //Dynamic Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

                if (attribute == null)
                    continue;

                var value = property.GetValue(data);
                if (value == null)
                    continue;

                dynamic fieldValue = new JObject();
                fieldValue.Id = attribute.EloquaCustomFieldId;
                fieldValue.Value = value.ToString();

                requestObject.FieldValues.Add(fieldValue);
            }
            var customDataPostUrl = requestObject["Id"] == null ? "" : $"/{requestObject["Id"]}";
            var requestUrl = $"{resourceAttribute.Uri}{customDataPostUrl}";
            var request = new RestRequest(requestUrl, Method.POST);

            var jObject = JsonConvert.DeserializeObject<ExpandoObject>(requestObject.ToString());
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var serialized = JsonConvert.SerializeObject(jObject, settings);

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await ExecuteWithErrorCheckAsync(request);

            return ConvertToConcreateClass(response.Content);
        }
        public async Task<T> PutAsync(T data)
        {
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new Exception("Connot determine the endpoint");

            dynamic requestObject = new JObject();
            requestObject.FieldValues = new JArray();
            requestObject.Type = resourceAttribute.Type;

            //Static Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var value = property.GetValue(data);
                if (value == null)
                    continue;

                requestObject[property.Name] = value.ToString();
            }

            //Dynamic Fields
            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

                if (attribute == null)
                    continue;

                var value = property.GetValue(data);
                if (value == null)
                    continue;

                dynamic fieldValue = new JObject();
                fieldValue.Id = attribute.EloquaCustomFieldId;
                fieldValue.Value = value.ToString();

                requestObject.FieldValues.Add(fieldValue);
            }
            var customDataPostUrl = requestObject["Id"] == null ? "" : $"/{requestObject["Id"]}";
            var requestUrl = $"{resourceAttribute.Uri}{customDataPostUrl}";
            var request = new RestRequest(requestUrl, Method.PUT);

            var jObject = JsonConvert.DeserializeObject<ExpandoObject>(requestObject.ToString());
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            var serialized = JsonConvert.SerializeObject(jObject, settings);

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await ExecuteWithErrorCheckAsync(request);

            return ConvertToConcreateClass(response.Content);
        }

        private async Task<IRestResponse> ExecuteWithErrorCheckAsync(IRestRequest request)
        {
            var response = await _restClient.ExecuteTaskAsync(request);

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Completed:
                    {
                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.OK:
                            case HttpStatusCode.Accepted:
                            case HttpStatusCode.Created:
                            case HttpStatusCode.Found:
                            case HttpStatusCode.NoContent:
                                return response;
                            case HttpStatusCode.NotFound:
                                {
                                    if (string.IsNullOrWhiteSpace(response.Content))
                                        return response;
                                    throw new Exception(response.Content);

                                }
                            case HttpStatusCode.Conflict:
                            case HttpStatusCode.BadRequest:
                                var validationErrors = JsonConvert.DeserializeObject<List<ObjectValidationError>>(response.Content);
                                throw new ValidationException(response, validationErrors);
                            default:
                                throw new Exception(response.Content);
                        }
                    }

                case ResponseStatus.Aborted:
                case ResponseStatus.TimedOut:
                    throw new ConnectionErrorException(response);
                default:
                    throw new Exception();// throw ResponseValidator.GetExceptionFromResponse(response);
            }
        }
        private T ConvertToConcreateClass(string content)
        {
            var dto = JsonConvert.DeserializeObject<EloquaDto>(content);
            var resultObject = JsonConvert.DeserializeObject<T>(content);

            if (dto == null || resultObject == null)
                return default(T);

            foreach (var property in resultObject.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;
                if (attribute == null)
                    continue;

                var fieldvalue = dto.FieldValues.FirstOrDefault(o => o.Id == attribute.EloquaCustomFieldId);
                if (fieldvalue == null)
                    continue;

                property.SetValue(resultObject, fieldvalue.Value);
            }
            return resultObject;
        }

        private class EloquaDto
        {
            public IEnumerable<FieldValue> FieldValues { get; } = new List<FieldValue>();
        }


    }
}
