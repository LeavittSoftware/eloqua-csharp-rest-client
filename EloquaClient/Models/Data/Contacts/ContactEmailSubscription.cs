using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Groups;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts
{
    [Resource("/data/contact", "ContactEmailSubscription")]
    public class ContactEmailSubscription : RestObject
    {
        public int? ContactId { get; set; }
        public EmailGroup EmailGroup { get; set; }
        public bool? IsSubscribed { get; set; }
        public int? UpdatedAt { get; set; }
    }
}
