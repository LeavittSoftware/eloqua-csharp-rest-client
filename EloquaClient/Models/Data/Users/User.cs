using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Users
{
    [ExcludeFromCodeCoverage]
    [Resource("/system/user", "User", "/api/REST/2.0")]
    public class User : IEloquaDataObject
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}
