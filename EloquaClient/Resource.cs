namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class Resource : System.Attribute
    {
        public Resource(string uri, string type)
        {
            Uri = uri;
            Type = type;
        }

        public string Uri { get; }

        public string Type { get; }
    }
}
