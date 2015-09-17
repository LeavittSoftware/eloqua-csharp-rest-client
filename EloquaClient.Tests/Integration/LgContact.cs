using LG.Eloqua.Api.Rest.ClientLibrary.Clients;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    [Resource("/data/contact", "Contact")]
    public class LgContact : Contact
    {
        [EloquaCustomProperty(100258)]
        public string RefUrl { get; set; }

        [EloquaCustomProperty(100256)]
        public string SmsText { get; set; }

        [EloquaCustomProperty(100014)]
        public string MobilePhone { get; set; }

        [EloquaCustomProperty(100193)]
        public string ResidentialPhone { get; set; }

        [EloquaCustomProperty(100011)]
        public string ZipCode { get; set; }

        [EloquaCustomProperty(100257)]
        public string HomeOwner { get; set; }

        [EloquaCustomProperty(100010)]
        public string State { get; set; }

        [EloquaCustomProperty(100214)]
        public string County { get; set; }
    }
}