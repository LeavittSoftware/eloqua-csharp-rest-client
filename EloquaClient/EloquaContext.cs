using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaContext
    {

        public EloquaContext(IRestClient restClient)
        {
            Contacts = new DbSet<Contact>(restClient);
        }

        public DbSet<Contact> Contacts { get; }

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
