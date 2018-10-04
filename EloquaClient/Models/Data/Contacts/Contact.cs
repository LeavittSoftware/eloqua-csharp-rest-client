using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts
{
    [ExcludeFromCodeCoverage]
    [Resource("/data/contact", "Contact")]
    public class Contact : IEloquaDataObject
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public string AccountName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string BusinessPhone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsSubscribed { get; set; }
        public bool? IsBounceBack { get; set; }
        public string SalesPerson { get; set; }
        public string Title { get; set; }
        [EloquaCustomProperty(100459)]
        public int? IsLocked { get; set; } 
        public List<FieldValue> FieldValues { get; set; }
    }
}
