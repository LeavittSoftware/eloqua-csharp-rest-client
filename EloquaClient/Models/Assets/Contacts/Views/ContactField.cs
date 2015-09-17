namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Views
{
    [Resource("/assets/contact/field", "ContactField")]
    public class ContactField : EloquaDto, ISearchable
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
        public string UpdateType { get; set; }
        public string DisplayType { get; set; }
        public string DataType { get; set; }
    }
}