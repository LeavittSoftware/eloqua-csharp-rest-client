using System.Runtime.Serialization;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email
{
    [KnownType(typeof(RawHtmlContent))]
    [KnownType(typeof(StructuredHtmlContent))]
    public class HtmlContent
    {
        public string ContentSource { get; set; }
        public string CssHeader { get; set; }
        public string DocType { get; set; }
        public string Html { get; set; }
        public string HtmlBody { get; set; }
        public int? Id { get; set; }
        public string JavascriptHeader { get; set; }
        public string Root { get; set; }
        public string Type { get; set; }
    }
}
