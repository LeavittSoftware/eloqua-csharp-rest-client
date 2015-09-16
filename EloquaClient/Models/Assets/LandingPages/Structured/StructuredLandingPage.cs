using LG.Eloqua.Api.Rest.ClientLibrary.Models.Content;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages.Structured
{
    [Resource("/assets/landingPage", "LandingPage")]
    public class LandingPage : RestObject, ISearchable
    {
        public int? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public StructuredHtmlContent HtmlContent { get; set; }
        public int? MicrositeId { get; set; }
        public string Style { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
