using Eloqua.Api.Rest.ClientLibrary.Models.Assets.ContentSections;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.DynamicContents
{
    [Resource("/assets/dynamicContent", "DynamicContent")]
    public class DynamicContent : RestObject, ISearchable
    {
        public ContentSection DefaultContentSection { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
