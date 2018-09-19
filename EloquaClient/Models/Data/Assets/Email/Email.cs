using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email
{
    [ExcludeFromCodeCoverage]
    [Resource("/assets/email", "Email", "/api/REST/2.0")]
    public class Email : IEloquaDataObject
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public string BouncebackEmail { get; set; }
        public int? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public string CurrentStatus { get; set; }
        public string Description { get; set; }
        public int? EmailFooterId { get; set; }
        public int? EmailGroupId { get; set; }
        public int? EmailHeaderId { get; set; }
        public int? EncodingId { get; set; }
        public int? FolderId { get; set; }
        public RawHtmlContent HtmlContent { get; set; }
        public bool IsPlainTextEditable { get; set; }
        public string PlainText { get; set; }
        public string ReplyToName { get; set; }
        public string ReplyToEmail { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public bool SendPlainTextOnly { get; set; }
        public string Subject { get; set; }
        public string Style { get; set; }
        public List<Hyperlink> Hyperlinks { get; set; }
        public string Type = "Email";
        public int? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
