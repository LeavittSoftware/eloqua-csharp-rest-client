using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Forms
{
    [Resource("/data/form", "FormData")]
    public class FormData : RestObject, ISearchable
    {
        public List<FieldValue> FieldValues { get; set; }
        public int? SubmittedAt { get; set; }
        public int? SubmittedByContactId { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
