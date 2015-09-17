namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections
{
    [Resource("/assets/contentSection", "ContentSection")]
    public class ContentSection : EloquaDto, ISearchable
    {
        public string ContentHtml { get; set; }
        public string ContentText { get; set; }
        public Size Size { get; set; }
        public string Scope { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
    }
}
