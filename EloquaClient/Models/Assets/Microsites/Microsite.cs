using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Microsites
{
    [Resource("/assets/microsite", "Microsite")]
    public class Microsite : RestObject, ISearchable
    {
        public int? DefaultLandingPageId { get; set; }
        public List<string> Domains { get; set; }
        public string EnableWebTrackingOptIn { get; set; }
        public bool? IsSecure { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
