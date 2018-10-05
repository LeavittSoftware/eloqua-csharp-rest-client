using System;
using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Assets.Email
{
    [Resource("/assets/email/deployment", "EmailDeployment", "/api/REST/2.0")]
    public class EmailDeployment : IEloquaDataObject
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public List<string> ContactIds { get; set; } = new List<string>();

        public int? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public string Description { get; set; }
        public string CurrentStatus { get; set; }
        public Email Email { get; set; }
        public int? EndAt { get; set; }
        public int? FailedSendCount { get; set; }
        public int? FolderId { get; set; }
        public string SentSubject { get; set; }
        public string SentContent { get; set; }
        public string SuccessfulSendCount { get; set; }
        public string Type { get; set; } = "EmailLowVolumeDeployment";
        public int? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
