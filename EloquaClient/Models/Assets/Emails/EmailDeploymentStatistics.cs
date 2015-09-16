namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails
{
    public class EmailDeploymentStatistics
    {
        public string BouncebackType { get; set; }
        public int? ClickThroughCount { get; set; }
        public string EmailAddress { get; set; }
        public long? LastClickThrough { get; set; }
        public long? LastOpen { get; set; }
        public int? OpenCount { get; set; }
        public long? SentAt { get; set; }
    }
}
