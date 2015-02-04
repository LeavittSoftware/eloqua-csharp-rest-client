using System;
using Eloqua.Api.Rest.ClientLibrary.Clients.Assets;
using Eloqua.Api.Rest.ClientLibrary.Clients.Data;
using Eloqua.Api.Rest.ClientLibrary.Clients.Systems;
using Eloqua.Api.Rest.ClientLibrary.Models.Account;
using RestSharp;

namespace Eloqua.Api.Rest.ClientLibrary
{
    public class Client : BaseClient
    {
        private readonly Lazy<AssetClient> assetClientLazy;
        private readonly Lazy<DataClient> dataLazy;
        private readonly Lazy<SystemClient> systemClientLazy;

        protected BaseClient BaseClient;

        public AssetClient Assets
        {
            get { return assetClientLazy.Value; }
        }

        public DataClient Data
        {
            get { return dataLazy.Value; }
        }

        public SystemClient Systems
        {
            get { return systemClientLazy.Value; }
        }

        public Client(string site, string user, string password, Uri baseUrl)
        {
            BaseClient = new BaseClient(site, user, password, baseUrl);
            assetClientLazy = new Lazy<AssetClient>(() => new AssetClient(BaseClient));
            dataLazy = new Lazy<DataClient>(() => new DataClient(BaseClient));
            systemClientLazy = new Lazy<SystemClient>(() => new SystemClient(BaseClient));
        }

        public static AccountInfo GetAccountInfo(string site, string user, string password)
        {
            var baseUrl = new Uri("https://login.eloqua.com");
            var client = new BaseClient(site, user, password, baseUrl);
            return client.Execute<AccountInfo>(new RestRequest("id", Method.GET));
        }
    }
}