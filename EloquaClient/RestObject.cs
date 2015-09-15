using System;

namespace Eloqua.Api.Rest.ClientLibrary
{
    public class RestObject : IIdentifiable
    {
        public int? Id { get; set; }
        public string name { get; set; }

        public string type;
        public string Depth { get; set; }

        public string Uri
        {
            get
            {
                if (!string.IsNullOrEmpty(_uri)) return _uri;
                var att = (Resource) Attribute.GetCustomAttribute(GetType(), typeof (Resource));
                _uri = att.Uri;
                return _uri;
            }
        }
        private string _uri;

        public string Type
        {
            get
            {
                if (!string.IsNullOrEmpty(_type)) return _type;
                var att = (Resource)Attribute.GetCustomAttribute(GetType(), typeof(Resource));
                _type = att.Type;
                return _type;
            }
        }
        private string _type;
    }
}
