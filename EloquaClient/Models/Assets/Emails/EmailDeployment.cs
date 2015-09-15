using System;

namespace Eloqua.Api.Rest.ClientLibrary.Models.Assets.Emails
{
    [Resource("/assets/email/deployment", "EmailDeployment")]
    public class EmailDeployment : RestObject, ISearchable
    {
        public Email Email { get; set; }
        public DateTime EndAt { get; set; }
        public int? FailedSendCount { get; set; }
        public string SentSubject { get; set; }
        public string SuccessfulSendCount { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}
