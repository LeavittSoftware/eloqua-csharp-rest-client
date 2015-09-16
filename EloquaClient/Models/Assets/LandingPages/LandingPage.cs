using System.Collections.Generic;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.DynamicContents;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Content;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.LandingPages
{
    [Resource("/assets/landingPage", "LandingPage")]
    public class LandingPage : RestObject, ISearchable
    {
        public List<ContentSection> ContentSections { get; set; }
        public int? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public List<DynamicContent> DynamicContents { get; set; }
        public RawHtmlContent HtmlContent { get; set; }
        public int? MicrositeId { get; set; }
        public string Style { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string Name { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
