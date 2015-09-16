namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails
{
    [Resource("/assets/email/deployment", "EmailTestDeployment")]
    public class EmailTestDeployment : RestObject, ISearchable
    {
        public int? ContactId { get; set; }
        public Email Email { get; set; }
        public int? SuccessfulSendCount { get; set; }
        public int? FailedSendCount { get; set; }
        public string EndAt { get; set; }
        public int? SendFromUserId { get; set; }
        public string SentContent { get; set; }
        public string SentSubject { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
