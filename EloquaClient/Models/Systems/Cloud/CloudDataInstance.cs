namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Systems.Cloud
{
    [Resource("/system/cloud/data", "CloudDataInstance")]
    public class CloudDataInstance : EloquaDto, ISearchable
    {
        public string ActivateUrl { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string IconUrl { get; set; }
        public string Name { get; set; }
        public string ProviderUrl { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
