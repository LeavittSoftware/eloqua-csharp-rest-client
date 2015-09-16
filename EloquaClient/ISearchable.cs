namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public interface ISearchable
    {
        int Page { get; set; }
        int PageSize { get; set; }
        string SearchTerm { get; set; }
    }
}
