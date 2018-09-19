namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class Resource : System.Attribute
    {
        public Resource(string uri, string type,string apiPath = "/api/REST/1.0/")
        {
            Uri = uri;
            Type = type;
            RestApiPath = apiPath;
        }

        public string RestApiPath { get; set; }
        public string Uri { get; }

        public string Type { get; }
    }
}
