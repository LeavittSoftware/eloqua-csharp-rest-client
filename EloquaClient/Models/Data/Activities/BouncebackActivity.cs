namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities
{
    [Resource("/data/activities/contact/", "BouncebackActivity")]
    public class BouncebackActivity : RestObject, ISearchable
    {
        public string SmtpErrorCode { get; set; }
        public string SmtpSatusCode { get; set; }
        public string SmtpMessage { get; set; }
        public int EmailId { get; set; }
        public string EmailName { get; set; }
        public string EmailFromAddress { get; set; }
        public string EmailToAddress { get; set; }
        public BouncebackType Category { get; set; }

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }
}