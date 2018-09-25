using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaContext : IEloquaContext
    {
        public EloquaContext(IRestClient restClient)
        {
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

      
    }
}
