using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Groups
{
    [Resource("/assets/email/group", "EmailGroup")]
    public class EmailGroup : RestObject, ISearchable
    {
        public string DisplayName { get; set; }
        public int? EmailFooterId { get; set; }
        public int? EmailHeaderId { get; set; }
        public List<string> EmailIds { get; set; }
        public bool? IsVisibleInOutlookPlugin { get; set; }
        public string SubscriptionListDataLookupId { get; set; }
        public int? SubscriptionLandingPageId { get; set; }
        public int? SubscriptionListId { get; set; }
        public string UnSubscriptionListDataLookupId { get; set; }
        public int? UnsubscriptionLandingPageId { get; set; }
        public int? UnSubscriptionListId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
    }
}