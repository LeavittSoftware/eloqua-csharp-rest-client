using System;
using System.Linq;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Models;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.CustomObjects;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients
{
    public class EloquaCustomObjectAttribute : Attribute
    {
        public EloquaCustomObjectAttribute(int eloquaCustomObjectId)
        {
            EloquaCustomObjectId = eloquaCustomObjectId;
        }
        public int EloquaCustomObjectId { get; set; }
    }

    public class EloquaCustomPropertyAttribute : Attribute
    {
        public EloquaCustomPropertyAttribute(int eloquaCustomFieldId)
        {
            EloquaCustomFieldId = eloquaCustomFieldId;
        }
        public int EloquaCustomFieldId { get; set; }
    }

    public interface ICustomEloquaObject
    {
        int Id { get; set; }
    }

    [EloquaCustomObject(37)]
    public class LLStep1 : ICustomEloquaObject
    {
        public int Id { get; set; }

        [EloquaCustomProperty(447)]
        public string HasOwned { get; set; }
    }




    public class EloquaCustomObjectClient<T> where T : ICustomEloquaObject, new()
    {
        public EloquaCustomObjectClient(BaseClient baseClient)
        {
            _baseClient = baseClient;
        }
        readonly BaseClient _baseClient;

        //public async Task<T> GetAsync(int id, Depth depth = Depth.Minimal)
        //{
        //    //var data = new T { Id = id, Depth = depth.ToString() };
        //   // return await _baseClient.GetAsync(data);
        //}

        public async Task<T> PostAsync(T data)
        {
            //data.GetType().Attributes.

            var customObject = new CustomObject();
            var eloquaCustomObjectAttribute = data.GetType().GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomObjectAttribute) as EloquaCustomObjectAttribute;

            if(eloquaCustomObjectAttribute == null)
                throw new Exception();

            customObject.Id = eloquaCustomObjectAttribute.EloquaCustomObjectId;

            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
            {
                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

                if(attribute == null)
                    continue;

                customObject.FieldValues.Add(new FieldValue { Id = attribute.EloquaCustomFieldId, Value = property.GetValue(data).ToString()});
            }

            var result = await _baseClient.PostAsync(customObject);

            //TODO: Fill out t
            return new T();
        }
    }
}