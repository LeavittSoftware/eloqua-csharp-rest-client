namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Account
{
    [Resource("/data/account", "Account")]
    public class Account : RestObject, ISearchable
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string BusinessPhone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FieldValues { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
