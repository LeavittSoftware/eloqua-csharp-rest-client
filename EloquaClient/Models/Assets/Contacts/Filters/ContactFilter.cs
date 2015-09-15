using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Filters.Criteria;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Filters
{
    public class ContactFilter : IdentifiableObject
    {
        public int? Count { get; set; }
        public List<Criterion> Criteria { get; set; }
        public string LastCalculatedAt { get; set; }
        public string Scope { get; set; }
        public string Statement { get; set; }
    }
}
