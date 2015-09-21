using System.Diagnostics.CodeAnalysis;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects
{
    [ExcludeFromCodeCoverage]
    [Resource("/data/customObject", "CustomObjectData")]
    public class CustomObjectData : IEloquaDataObject
    {
        public int? Id { get; set; }
    }


}
