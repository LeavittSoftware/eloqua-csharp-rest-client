﻿namespace Eloqua.Api.Rest.ClientLibrary.Models.Content
{
    public class StructuredHtmlContent
    {
        public string CssHeader { get; set; }
        public string DocType { get; set; }
        public string HtmlBody { get; set; }
        public int? Id { get; set; }
        public string JavascriptHeader { get; set; }
        public string Root { get; set; }
        public string Type
        {
            get { return "StructuredHtmlContent"; }
        }
    }
}
