using System.Collections.Generic;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Campaigns
{
    [Resource("/assets/campaign", "Campaign")]
    public class Campaign : RestObject, ISearchable
    {
        public int? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? FolderId { get; set; }
        public string Name { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public float? ActualCost { get; set; }
        public float? BudgetedCost { get; set; }
        public string CampaignType { get; set; }
        public List<CampaignRelatedElement> Elements { get; set; }
        public int? StartAt { get; set; }
        public int? EndAt { get; set; }
        public bool? IsIncludedInRoi { get; set; }
        public bool? IsMemberAllowedReEntry { get; set; }
        public bool? IsReadOnly { get; set; }
        public bool? IsSyncedWithCrm { get; set; }
        public int? RunAsUserId { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
