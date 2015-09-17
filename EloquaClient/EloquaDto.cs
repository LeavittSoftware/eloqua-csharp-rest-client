using System;
using System.Collections.Generic;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using Newtonsoft.Json;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaDto : IIdentifiable, ISearchable
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
       

        public List<FieldValue> FieldValues { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        [JsonIgnore]
        public string Depth { get; set; }

        [JsonIgnore]
        public string Uri { get; set; }

        [JsonIgnore]
        public string DeclaredType { get; set; }
    }
}
