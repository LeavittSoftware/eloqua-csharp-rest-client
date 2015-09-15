using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Segments
{
    [Resource("/assets/contact/segment", "ContactSegment")]
    public class ContactSegment : RestObject, ISearchable
    {
        public int? Count { get; set; }
        public string LastCalculatedAt { get; set; }
        public List<SegmentElement> Elements { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }


}
