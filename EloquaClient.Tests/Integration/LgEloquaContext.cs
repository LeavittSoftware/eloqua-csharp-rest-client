using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
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
            Emails = new DbSet<Email>(restClient);
            EmailDeployments = new DbSet<EmailDeployment>(restClient);
            Campaigns = new DbSet<Campaign>(restClient);
        }

        public DbSet<BadContact> BadContacts { get; }
        public DbSet<Campaign> Campaigns { get; }
        public DbSet<Email> Emails { get; }
        public DbSet<EmailDeployment> EmailDeployments { get; }
        public DbSet<ExtendedContact> ExtendedContacts { get; }
        public DbSet<LgContact> LgContacts { get; }


    }
}