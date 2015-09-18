﻿using System;
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
                throw new DbSetException();

            var request = new RestRequest($"{resourceAttribute.Uri}/{{id}}", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddUrlSegment("id", id.ToString());

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaSerializer.Serializer<T>(response.Content);
        }
        public async Task<List<T>> SearchAsync(string searchTerm, int pageSize = 1000, int page = 1, Depth depth = Depth.Complete)
        {
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new DbSetException();

            var request = new RestRequest($"{resourceAttribute.Uri}s", Method.GET);
            request.AddParameter("depth", depth.ToString());
            request.AddParameter("count", pageSize.ToString());
            request.AddParameter("page", page.ToString());
            request.AddParameter("search", searchTerm);

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            var searchObject = JObject.Parse(response.Content);

            var elements = searchObject["elements"] as JArray;
            return elements?.Select(o => EloquaSerializer.Serializer<T>(response.Content) ).ToList() ?? new List<T>();
        }
        public async Task<T> PostAsync(T data)
        {
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new DbSetException();

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

                var value = property.GetValue(data);
                if (value == null)
                    continue;

                dynamic fieldValue = new JObject();
                fieldValue.Id = attribute?.EloquaCustomFieldId;
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

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaSerializer.Serializer<T>(response.Content);
        }
        public async Task<T> PutAsync(T data)
        {
            var resourceAttribute = Attribute.GetCustomAttribute(typeof(T), typeof(Resource)) as Resource;
            if (resourceAttribute == null)
                throw new DbSetException();

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

                var value = property.GetValue(data);
                if (value == null)
                    continue;

                dynamic fieldValue = new JObject();
                fieldValue.Id = attribute?.EloquaCustomFieldId;
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

            var response = await _restClient.ExecuteTaskAsync(request);

            response = EloquaResponseHandler.ErrorCheck(response);

            return EloquaSerializer.Serializer<T>(response.Content);
        }

    }
}
