﻿using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Models.Data.Activities;
using RestSharp;

namespace Eloqua.Api.Rest.ClientLibrary.Clients.Data
{
    public class ActivityClient
    {
        public ActivityClient(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }
        readonly BaseClient _baseClient;

        public List<Activity> Get(int? id, string type, int count, long startDate, long endDate, int page)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                Resource = $"/data/activities/contact/{id}/{type}?count={count}&startAt={startDate}&endAt={endDate}&page={page}"
            };

            return _baseClient.Execute<List<Activity>>(request);
        }

        public List<BouncebackActivity> Get(int? id, int count, long startDate, long endDate, int page)
        {
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                RootElement = "elements",
                Resource = $"/data/activities/contact/{id}/automation/bounceback?count={count}&startAt={startDate}&endAt={endDate}&page={page}"
            };

            return _baseClient.Execute<List<BouncebackActivity>>(request);
        }
    }
}
