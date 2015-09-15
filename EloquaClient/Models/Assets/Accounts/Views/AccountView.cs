using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Accounts.Views
{
    [Resource("/assets/account/view", "AccountView")]
    public class AccountView : RestObject, ISearchable
    {
        public List<DataField> Fields { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion

    }
}
