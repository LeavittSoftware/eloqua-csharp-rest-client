using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Groups;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts
{
    [Resource("/data/contact", "ContactEmailSubscription")]
    public class ContactEmailSubscription : EloquaDto
    {
        public int? ContactId { get; set; }
        public EmailGroup EmailGroup { get; set; }
        public bool? IsSubscribed { get; set; }
        public int? UpdatedAt { get; set; }
    }
}
