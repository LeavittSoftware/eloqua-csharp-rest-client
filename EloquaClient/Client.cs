using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Clients.Assets;
using LG.Eloqua.Api.Rest.ClientLibrary.Clients.Data;
using LG.Eloqua.Api.Rest.ClientLibrary.Clients.Systems;

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

        public Client(BaseClient baseClient)
        {
            _assetClientLazy = new Lazy<AssetClient>(() => new AssetClient(baseClient));
            _dataLazy = new Lazy<DataClient>(() => new DataClient(baseClient));
            _systemClientLazy = new Lazy<SystemClient>(() => new SystemClient(baseClient));
        }

        //public static AccountInfo GetAccountInfo(string site, string user, string password)
        //{
        //    var baseUrl = new Uri("https://login.eloqua.com");
        //    var client = new BaseClient(site, user, password, baseUrl);
        //    return ExecuteWithErrorHandling<AccountInfo>(new RestRequest("id", Method.GET));
        //}
    }
}