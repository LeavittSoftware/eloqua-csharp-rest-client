using LG.Eloqua.Api.Rest.ClientLibrary.Models.Content;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails.Deployment
{
    public class Email
    {
        public string BouncebackEmail { get; set; }
        public int? EmailFooterId { get; set; }
        public int? EmailGroupId { get; set; }
        public int? EmailHeaderId { get; set; }
        public int? EncodingId { get; set; }
        public RawHtmlContent HtmlContent { get; set; }
        public int? Id { get; set; }
        public bool IsPlainTextEditable { get; set; }
        public string Name { get; set; }
        public string PlainText { get; set; }
        public string ReplyToName { get; set; }
        public string ReplyToEmail { get; set; }
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public bool SendPlainTextOnly { get; set; }
        public string Subject { get; set; }
    }
}
