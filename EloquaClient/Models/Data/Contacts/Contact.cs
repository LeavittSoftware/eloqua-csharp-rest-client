using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts
{
    [Resource("/data/contact", "Contact")]
    public class Contact : RestObject, ISearchable
    {
        public string AccountName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string BusinessPhone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsSubscribed { get; set; }
        public bool? IsBounceBack { get; set; }
        public string SalesPerson { get; set; }
        public string Title { get; set; }
        public List<FieldValue> FieldValues { get; set; }

        public string Name => EmailAddress; // TODO : add attribute to ignore these properties

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
