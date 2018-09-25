using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaContext : IEloquaContext
    {
        private readonly IRestClient _restClient;

        public EloquaContext(IRestClient restClient)
        {
            _restClient = restClient;
            Contacts = new DbSet<Contact>(restClient);
            Bulk = new BulkApi(restClient);
            Campaigns = new DbSet<Campaign>(restClient);
            Emails = new DbSet<Email>(restClient);
            EmailDeployments = new DbSet<EmailDeployment>(restClient);
        }

        public IBulkApi Bulk { get; }
        public IDbSet<Contact> Contacts { get; }
        public IDbSet<Campaign> Campaigns { get; }
        public IDbSet<Email> Emails { get; }
        public IDbSet<EmailDeployment> EmailDeployments { get; }

        public static IRestClient CreateClient(string site, string username, string password, Uri baseUri)
        {
            var restClient = new RestClient
            {
                BaseUrl = baseUri,
                Authenticator = new HttpBasicAuthenticator(site + "\\" + username, password)
            };
            restClient.AddHandler("text/plain", new JsonDeserializer());
            return restClient;
        }


        public async Task<Result> DisableCustomCampaignObjectsAsync(long customObjectInstanceId,long activationId, long customObjectschemaId = 121)
        {

            const string restApiPath = "/api/REST/2.0/data/";
        

            var requestUrl = $"{restApiPath}customObject/{customObjectschemaId}/instance/{customObjectInstanceId}";
            var request = new RestRequest(requestUrl, Method.PUT);

            dynamic customObjectData = new ExpandoObject();
            dynamic fieldValue = new ExpandoObject();


            fieldValue.id = activationId;
            fieldValue.value = 0;

            customObjectData.fieldValues = new List<object> { fieldValue };

            var serialized = JsonConvert.SerializeObject(customObjectData, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            request.AddParameter("application/json", serialized, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            var response = await _restClient.ExecuteTaskAsync(request);


            return response.StatusCode == HttpStatusCode.OK? Result.FromSuccess(): Result.FromError(response.ErrorMessage);

        }

        //public async Task<List<CustomCampaignObjectDto>> DisableCustomCampaignObjectsAsync(List<CustomCampaignObjectDto> customCampaignObjectDtos)
        //{

        //    const string restApiPath = "/api/REST/2.0/data/";
        //    const long customObjectschemaId = 121;
        //    foreach (var customCampaignObjectDto in customCampaignObjectDtos)
        //    {

        //        var requestUrl = $"{restApiPath}customObject/{customObjectschemaId}/instance/{customCampaignObjectDto.InstanceId}";
        //        var request = new RestRequest(requestUrl, Method.PUT);

        //        dynamic customObjectData = new ExpandoObject();
        //        dynamic fieldValue = new ExpandoObject();


        //        fieldValue.id = customCampaignObjectDto.ActivationId;
        //        fieldValue.value = 0;

        //        customObjectData.fieldValues = new List<object> { fieldValue };

        //        var serialized = JsonConvert.SerializeObject(customObjectData, Formatting.None,
        //            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        //        request.AddParameter("application/json", serialized, ParameterType.RequestBody);
        //        request.RequestFormat = DataFormat.Json;

        //        var response = await _restClient.ExecuteTaskAsync(request);

        //        customCampaignObjectDto.Status = response.StatusCode;
        //    }

        //    return customCampaignObjectDtos;
        //}
    }
}
