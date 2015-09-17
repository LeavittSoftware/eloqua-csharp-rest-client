using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Lists
{
    [Resource("/assets/contact/list", "ContactList")]
    public class ContactList : EloquaDto, ISearchable
    {
        public int? Count { get; set; }
        public List<string> MembershipAdditions { get; set; }
        public List<string> MembershipDeletions { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion

    }
}
