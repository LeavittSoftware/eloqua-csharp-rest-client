namespace Eloqua.Api.Rest.ClientLibrary.Models.Data.ExternalActivities
{
    [Resource("/data/activity", "ExternalActivities")]
    public class ExternalActivities
    {
        public string Type { get; set; }
        public string CampaignId { get; set; }
        public string AssetName { get; set; }
        public string AssetType { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDate { get; set; }
        public string ContactId { get; set; }
    }
}
