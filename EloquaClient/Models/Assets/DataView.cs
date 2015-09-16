using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets
{
    public class DataView : IdentifiableObject
    {
        public List<DataField> Fields { get; set; }
    }
}
