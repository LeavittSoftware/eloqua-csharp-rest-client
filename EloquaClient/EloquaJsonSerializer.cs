using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using Newtonsoft.Json;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaJsonSerializer
    {
        public static T Deserializer<T>(string content)
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



                var type = property.PropertyType;

                int unixTimeValue;
                if (type == typeof(DateTime) && int.TryParse(fieldvalue.Value, out unixTimeValue))
                {
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
                    epoch = epoch.AddSeconds(unixTimeValue);
                    property.SetValue(resultObject, epoch);
                }
                else
                {
                    try
                    {
                        property.SetValue(resultObject,
                            TypeDescriptor.GetConverter(type).ConvertFromString(fieldvalue.Value));
                    }
                    catch (Exception)
                    {
                        if (type.IsValueType)
                        {
                            property.SetValue(resultObject, Activator.CreateInstance(type));
                        }
                        property.SetValue(resultObject, null);
                    }
                }
            }
            return resultObject;
        }


        /// <summary>
        /// Converts properties to Eloqua formatted strings
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeProperty(PropertyInfo propertyInfo, object obj)
        {
            string eloquaString;
            var value = propertyInfo.GetValue(obj);

            if (value == null)
                return null;

            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                eloquaString = (((DateTime)value) - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds.ToString(CultureInfo.InvariantCulture);
            }
            else if (propertyInfo.PropertyType == typeof(decimal))
            {
                eloquaString = (((decimal)value).ToString("F19"));
            }
            else
            {
                eloquaString = value.ToString();
            }
            return eloquaString;
        }

        private class EloquaDto
        {
            public IEnumerable<FieldValue> FieldValues { get; } = new List<FieldValue>();
        }
    }


}
