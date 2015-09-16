using LG.Eloqua.Api.Rest.ClientLibrary.Models.Conditions;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Contacts.Filters.Criteria
{
    public class ActivityCriterion : Criterion
    {
        public Condition ActivityRestriction { get; set; }
        public Condition TimeRestriction { get; set; }
    }
}
