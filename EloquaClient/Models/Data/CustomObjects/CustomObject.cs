using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects
{
    [Resource("/data/customObject", "CustomObject")]
    public class CustomObject : RestObject, ISearchable
    {
        public int? ContactId { get; set; }
        public string CurrentStatus { get; set; }
        public List<FieldValue> FieldValues { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
