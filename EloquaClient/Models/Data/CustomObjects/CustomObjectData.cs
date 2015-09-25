using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects
{
    [ExcludeFromCodeCoverage]
    [Resource("/data/customObject", "CustomObjectData")]
    public class CustomObjectData : IEloquaDataObject
    {
        public int? Id { get; set; }

        public static string GenerateImportFieldMapping<T>(T customObjectData) where T : IEloquaDataObject
        {
            var customAttributeNumber = customObjectData
                .GetType()
                .GetCustomAttributes(true)
                .OfType<EloquaCustomObjectAttribute>()
                .FirstOrDefault()?
                .CustomObjectId;
            var sb = new StringBuilder();

            customObjectData.GetType()
                       .GetProperties()
                       .Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), true))
                       .ToList()
                       .ForEach(property =>
                       {
                           var attribute = (EloquaCustomPropertyAttribute)property.GetCustomAttributes(true).First(o => o is EloquaCustomPropertyAttribute);

                           sb.Append($@"""{property.Name}"": ""{{{{CustomObject[{customAttributeNumber?.ToString()}].Field[{attribute.EloquaCustomFieldId}]}}}}"",");
                       });

            return sb.ToString();
        }
    }
}
