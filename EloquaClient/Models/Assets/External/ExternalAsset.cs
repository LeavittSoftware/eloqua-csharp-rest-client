namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.External
{
    [Resource("/assets/external", "ExternalAsset")]
    public class ExternalAsset : RestObject, ISearchable
    {
        public int? ExternalAssetTypeId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
    }
}
