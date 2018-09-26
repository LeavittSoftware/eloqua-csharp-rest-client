using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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

                var fieldValue = dto.FieldValues.FirstOrDefault(o => o.Id == attribute?.EloquaCustomFieldId);
                if (fieldValue == null)
                    continue;

                var type = property.PropertyType;

                int unixTimeValue;
                if ((type == typeof(DateTime?) || type == typeof(DateTime)) && int.TryParse(fieldValue.Value, out unixTimeValue))
                {
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
                    epoch = epoch.AddSeconds(unixTimeValue);
                    property.SetValue(resultObject, epoch);
                }
                else
                {
                    try
                    {
                        if (type == typeof(Nullable) || type == typeof(int?))
                        {
                            Type u = Nullable.GetUnderlyingType(type);
                            property.SetValue(resultObject,
                                TypeDescriptor.GetConverter(u).ConvertFromString(Convert.ToInt32(Convert.ToDouble(fieldValue.Value)).ToString()));
                        }
                        else
                        {
                            property.SetValue(resultObject,
                                TypeDescriptor.GetConverter(type).ConvertFromString(fieldValue.Value));
                        }
                    }
                    catch (Exception e)
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

        public static T Deserializer<T>(EloquaDto dto, T resultObject)
        {
            if (dto == null || resultObject == null)
                return default(T);

            foreach (var property in resultObject.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = (EloquaCustomPropertyAttribute)property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute);

                var fieldValue = dto.FieldValues.FirstOrDefault(o => o.Id == attribute?.EloquaCustomFieldId);
                if (fieldValue == null)
                    continue;

                var type = property.PropertyType;

                int unixTimeValue;
                if ((type == typeof(DateTime?) || type == typeof(DateTime)) && int.TryParse(fieldValue.Value, out unixTimeValue))
                {
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
                    epoch = epoch.AddSeconds(unixTimeValue);
                    property.SetValue(resultObject, epoch);
                }
                else
                {
                    try
                    {
                        if (type == typeof(Nullable) || type == typeof(int?))
                        {
                            Type u = Nullable.GetUnderlyingType(type);
                            property.SetValue(resultObject,
                                TypeDescriptor.GetConverter(u).ConvertFromString(Convert.ToInt32(Convert.ToDouble(fieldValue.Value)).ToString()));
                        }
                        else
                        {
                            property.SetValue(resultObject,
                                TypeDescriptor.GetConverter(type).ConvertFromString(fieldValue.Value));
                        }
                    }
                    catch (Exception e)
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
        public static dynamic SerializeProperty(PropertyInfo propertyInfo, object obj)
        {
            dynamic eloquaString;
            var value = propertyInfo.GetValue(obj);

            if (value == null)
                return null;

            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                eloquaString = ((DateTime)value - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds.ToString("F0", CultureInfo.InvariantCulture);
            }
            else if (propertyInfo.PropertyType == typeof(DateTime?))
            {
                eloquaString = ((DateTime?)value - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).Value.TotalSeconds.ToString("F0", CultureInfo.InvariantCulture);
            }
            else if (propertyInfo.PropertyType == typeof(decimal))
            {
                eloquaString = ((decimal)value).ToString("F19");
            }
            else if (propertyInfo.PropertyType == typeof(string) || propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(int?))
            {
                eloquaString = value;
            }
            else
            {
                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), NullValueHandling = NullValueHandling.Ignore };
                var serialized = JsonConvert.SerializeObject(value, settings);
                eloquaString = JToken.Parse(serialized);
            }

            return eloquaString;
        }

        public class EloquaDto
        {
            public IEnumerable<FieldValue> FieldValues { get; } = new List<FieldValue>();
        }
    }


}
