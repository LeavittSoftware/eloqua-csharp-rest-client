using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.CustomObjects
{
    [Resource("/assets/customObject", "CustomObject")]
    public class CustomObject : RestObject, ISearchable
    {
        public string DisplayNameFieldId { get; set; }
        public List<CustomObjectField> Fields { get; set; }
        public string UniqueCodeFieldId { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
