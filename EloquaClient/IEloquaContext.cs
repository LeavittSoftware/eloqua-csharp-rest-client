using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Campaign;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public interface IEloquaContext
    {
        IBulkApi Bulk { get; }
        IDbSet<Contact> Contacts { get; }
        IDbSet<Campaign> Campaigns { get; }
        IDbSet<Email> Emails { get; }
        IDbSet<EmailDeployment> EmailDeployments { get; }
        Task<Result> DisableCustomCampaignObjectsAsync(long customObjectInstanceId,long activationId, long customObjectschemaId = 121);
        Task<Result> UpdateCustomCampaignObjectsAsync(int state, long customObjectInstanceId, long activationId, long customObjectschemaId = 121);

        Task<List<CustomObjectData>> SearchCustomCampaignObjectsAsync(string searchTerm,
            long customObjectschemaId = 121);

        Task<IRestResponse> CreateCustomCampaignObjectsAsync(string emailAddress, long eloquaContactId, int state,
            long activationId, long customObjectschemaId = 121, long customObjectMappingFieldId = 2111);
    }
}