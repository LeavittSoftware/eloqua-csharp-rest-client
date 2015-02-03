using System;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities;
using Xunit;

namespace Eloqua.Api.Rest.ClientLibrary.Tests.Clients.Data
{
    public class ActivityClientTests
    {
        private readonly Client client;

        public ActivityClientTests()
        {
            client = new Client("site", "user", "password", Constants.BaseUrl);
        }

        #region helpers

        private static long ConvertToUnixEpoch(DateTime date)
        {
            return (long) new TimeSpan(date.Ticks - _unixEpochTime.Ticks).TotalSeconds;
        }

        private static DateTime _unixEpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #endregion

        [Fact]
        public void GetActivitiesTest()
        {
            var activities = client.Data.Activity.Get(7120511, ActivityType.externalActivity.ToString(), 1000,
                ConvertToUnixEpoch(new DateTime(2012, 01, 01)),
                ConvertToUnixEpoch(new DateTime(2012, 08, 01)), 1);

            Assert.True(activities.Count > 0);
        }
    }
}