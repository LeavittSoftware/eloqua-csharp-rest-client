using LG.Eloqua.Api.Rest.ClientLibrary.Clients;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    [Resource("/data/contact", "Contact")]
    public class ExtendedContact : Contact
    {

        [EloquaCustomProperty(10011111)]
        public string Test { get; set; }
    }
}