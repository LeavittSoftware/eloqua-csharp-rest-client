using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Clients.Assets;
using LG.Eloqua.Api.Rest.ClientLibrary.Clients.Data;
using LG.Eloqua.Api.Rest.ClientLibrary.Clients.Systems;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public sealed class Client
    {
        private readonly Lazy<AssetClient> _assetClientLazy;
        private readonly Lazy<DataClient> _dataLazy;
        private readonly Lazy<SystemClient> _systemClientLazy;

        public AssetClient Assets => _assetClientLazy.Value;

        public DataClient Data => _dataLazy.Value;

        public SystemClient Systems => _systemClientLazy.Value;

        public Client(string site, string username, string password, Uri baseUri)
        {
            var restClient = new RestClient
            {
                BaseUrl = baseUri,
                Authenticator = new HttpBasicAuthenticator(site + "\\" + username, password)
            };
            restClient.AddHandler("text/plain", new JsonDeserializer());

            _dataLazy = new Lazy<DataClient>(() => new DataClient(restClient));
        }


        public Client(IRestClient restClient)
        {
            // _assetClientLazy = new Lazy<AssetClient>(() => new AssetClient(restClient));
            _dataLazy = new Lazy<DataClient>(() => new DataClient(restClient));
            //  _systemClientLazy = new Lazy<SystemClient>(() => new SystemClient(restClient));
        }

        //public static AccountInfo GetAccountInfo(string site, string user, string password)
        //{
        //    var baseUrl = new Uri("https://login.eloqua.com");
        //    var client = new BaseClient(site, user, password, baseUrl);
        //    return ExecuteWithErrorHandling<AccountInfo>(new RestRequest("id", Method.GET));
        //}
    }
}