﻿namespace Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts
{
    [Resource("/data/contacts/list", "Contact")]
    public class ContactListMember : RestObject, ISearchable
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }
    }
}
