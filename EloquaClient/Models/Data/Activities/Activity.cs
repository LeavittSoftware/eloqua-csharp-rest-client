using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities
{
    [Resource("/data/activities/contact/", "Activity")]
    public class Activity : RestObject, ISearchable
    {
        public int ActivityDate { get; set; }
        public int Asset { get; set; }
        public string ActivityType { get; set; }
        public string AssetType { get; set; }
        public int Contact { get; set; }
        public List<Dictionary<string, string>> Details { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
