using System.Runtime.Serialization;
using Eloqua.Api.Rest.ClientLibrary.Models;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Segments
{
    [KnownType(typeof(ContactFilterSegmentElement))]
    public class SegmentElement : IdentifiableObject
    {
        public int? Count { get; set; }
        public bool? IsIncluded { get; set; }
        public string LastCalculatedAt { get; set; }
    }
}