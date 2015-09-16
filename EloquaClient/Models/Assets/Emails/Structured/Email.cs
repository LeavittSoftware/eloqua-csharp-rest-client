using System.Collections.Generic;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Hyperlinks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Content;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Structured
{
    [Resource("/assets/email", "Email")]
    public class Email : RestObject, ISearchable
    {
        public string BouncebackEmail { get; set; }
        public int? EmailFooterId { get; set; }
        public int? EmailGroupId { get; set; }
        public int? EmailHeaderId { get; set; }
        public int? EncodingId { get; set; }
        public StructuredHtmlContent HtmlContent { get; set; }
        public bool IsPlainTextEditable { get; set; }
        public string PlainText { get; set; }
        public string ReplyToName { get; set; }
        public string ReplyToEmail { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public bool SendPlainTextOnly { get; set; }
        public string Subject { get; set; }
        public List<Hyperlink> Hyperlinks { get; set; }
        public new string type = "Email";

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
