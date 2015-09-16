using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects
{
    [Resource("/data/customObject", "CustomObjectData")]
    public class CustomObject : RestObject, ISearchable
    {
        public int? ContactId { get; set; }
        public string CurrentStatus { get; set; }
        public List<FieldValue> FieldValues { get; set; } = new List<FieldValue>();

        #region ISearchable

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchTerm { get; set; }

        #endregion
    }

    //public class LLStep1 : CustomObject
    //{
    //    [JsonIgnore]
    //    public string WasInsuredLast30
    //    {
    //        get
    //        {
    //            var field = FieldValues.FirstOrDefault(o => o.Id == 447);
    //            return field?.Value;
    //        }
    //        set
    //        {
    //            var field = FieldValues.FirstOrDefault(o => o.Id == 447);
    //            if (field == null)
    //                FieldValues.Add(new FieldValue { Id = 447, Value = value });
    //            else
    //                field.Value = value;
    //        }
    //    }
    //}
}
