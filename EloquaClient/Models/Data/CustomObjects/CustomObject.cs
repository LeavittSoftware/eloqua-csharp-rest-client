using System.Collections.Generic;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects
{
    [Resource("/data/customObject", "CustomObjectData")]
    public class CustomObject : EloquaDto
    {
        public int? ContactId { get; set; }
        public string CurrentStatus { get; set; }
      
    }

   
}
