using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class DataClient
    {
        public DataClient(IRestClient restClient)
        {
            Contacts = new DbSet<Contact>(restClient);
        }

        public DbSet<Contact> Contacts { get; } 
    }
}
