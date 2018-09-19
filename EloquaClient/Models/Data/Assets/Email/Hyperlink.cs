namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email
{
    public class Hyperlink
    {
        public string href { get; set; }
        public string Type { get; set; } //hyperlinkType according to endpoint
        public string Id { get; set; } //referencedEntityId according to endpoint
    }
}
