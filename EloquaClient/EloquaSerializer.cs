using System;
using System.Collections.Generic;
using System.Linq;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using Newtonsoft.Json;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaSerializer
    {
        public static T Serializer<T>(string content)
        {
            var dto = JsonConvert.DeserializeObject<EloquaDto>(content);
            var resultObject = JsonConvert.DeserializeObject<T>(content);

            if (dto == null || resultObject == null)
                return default(T);

            foreach (var property in resultObject.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = (EloquaCustomPropertyAttribute)property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute);

                var fieldvalue = dto.FieldValues.FirstOrDefault(o => o.Id == attribute?.EloquaCustomFieldId);
                if (fieldvalue == null)
                    continue;

                property.SetValue(resultObject, fieldvalue.Value);
            }
            return resultObject;
        }
        private class EloquaDto
        {
            public IEnumerable<FieldValue> FieldValues { get; } = new List<FieldValue>();
        }
    }


}
