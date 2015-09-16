using System;
using Newtonsoft.Json;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class RestObject : IIdentifiable
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Depth { get; set; }

        [JsonIgnore]
        public string Uri
        {
            get
            {
                var att = (Resource)Attribute.GetCustomAttribute(GetType(), typeof(Resource));
                return att.Uri;
            }
        }

        [JsonIgnore]
        public string DeclaredType
        {
            get
            {
                var att = (Resource)Attribute.GetCustomAttribute(GetType(), typeof(Resource));
                return att.Type;
            }
        }
    }
}
