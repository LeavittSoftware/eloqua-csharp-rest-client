using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.OptionLists
{
    [Resource("/assets/optionList", "OptionList")]
    public class OptionList : RestObject, ISearchable
    {
        public List<Option> Elements { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
