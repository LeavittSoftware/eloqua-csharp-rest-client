using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    public class LgEloquaContext : EloquaContext
    {
        public LgEloquaContext(IRestClient restClient) : base(restClient)
        {
            BadContacts = new DbSet<BadContact>(restClient);
            LgContacts = new DbSet<LgContact>(restClient);
            ExtendedContacts = new DbSet<ExtendedContact>(restClient);
        }

        public DbSet<BadContact> BadContacts { get; }
        public DbSet<LgContact> LgContacts { get; }
        public DbSet<ExtendedContact> ExtendedContacts { get; }

    }
}