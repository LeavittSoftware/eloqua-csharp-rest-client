using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public interface IEloquaContext
    {
        IBulkApi Bulk { get; }
        IDbSet<Contact> Contacts { get; }
        IDbSet<Campaign> Campaigns { get; }
        IDbSet<Email> Emails { get; }
        IDbSet<EmailDeployment> EmailDeployments { get; }

    }
}