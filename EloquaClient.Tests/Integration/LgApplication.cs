using System;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Tests.Integration
{
    [EloquaCustomObject(37)]
    public class LgApplication : CustomObjectData
    {

        [EloquaCustomProperty(824)]
        public string ApplicationId { get; set; }

        [EloquaCustomProperty(446)]
        public DateTime? PolicyStartDate { get; set; }

        [EloquaCustomProperty(447)]
        public string InsuredInLast30 { get; set; }

        [EloquaCustomProperty(449)]
        public DateTime? CurrentPolicyExpirationDate { get; set; }

        [EloquaCustomProperty(448)]
        public string MonthsInsured { get; set; }

        [EloquaCustomProperty(450)]
        public string CurrentLiabilityLimits { get; set; }

        private string _contactId;
        [EloquaCustomProperty(966)]
        public string ContactId
        {
            get { return _contactId; }
            set
            {
                var contactId = 0;
                _contactId = !int.TryParse(value, out contactId) ? value : $"CLGAA{contactId.ToString("D12")}";
            }
        }
    }
}
