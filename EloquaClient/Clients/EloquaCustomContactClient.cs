//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using LG.Eloqua.Api.Rest.ClientLibrary.Models;
//using LG.Eloqua.Api.Rest.ClientLibrary.Models.Data.Contacts;

//namespace LG.Eloqua.Api.Rest.ClientLibrary.Clients
//{
//    class EloquaCustomContactClient
//    {
//    }

//    public class EloquaCustomContactClient<T> where T : IEloquaDataObject, new()
//    {
//        public EloquaCustomContactClient(BaseClient baseClient)
//        {
//            _baseClient = baseClient;
//        }
//        readonly BaseClient _baseClient;

//        public T Get(int id, Depth depth = Depth.Minimal)
//        {
//            return GetAsync(id, depth).Result;
//        }

//        public async Task<T> GetAsync(int id, Depth depth = Depth.Minimal)
//        {
//            var data = new Contact { Id = id, Depth = depth.ToString() };
//            var result = await _baseClient.GetAsync(data);

//            //TODO: Fill out t
//            return new T();
//        }

//        public T Post(T data)
//        {
//            return PostAsync(data).Result;
//        }

//        public async Task<T> PostAsync(T data)
//        {
//            var contact = new Contact();

//            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
//            {
//                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

//                if (attribute == null)
//                    continue;

//                contact.FieldValues.Add(new FieldValue { Id = attribute.EloquaCustomFieldId, Value = property.GetValue(data).ToString() });
//            }

//            var result = await _baseClient.PostAsync(contact);

//            //TODO: Fill out t
//            return new T();
//        }

//        public T Put(T data)
//        {
//            return PutAsync(data).Result;
//        }

//        public async Task<T> PutAsync(T data)
//        {
//            var contact = new Contact {Id = data.Id};

//            foreach (var property in data.GetType().GetProperties().Where(prop => prop.IsDefined(typeof(EloquaCustomPropertyAttribute), false)))
//            {
//                var attribute = property.GetCustomAttributes(true).FirstOrDefault(o => o is EloquaCustomPropertyAttribute) as EloquaCustomPropertyAttribute;

//                if (attribute == null)
//                    continue;

//                contact.FieldValues.Add(new FieldValue { Id = attribute.EloquaCustomFieldId, Value = property.GetValue(data).ToString() });
//            }

//            var result = await _baseClient.PutAsync(contact);

//            //TODO: Fill out t
//            return new T();
//        }

//        public async Task DeleteAsync(int? id)
//        {
//            var data = new Contact { Id = id };
//            await _baseClient.DeleteAsync(data);
//        }

//        public void Delete(int? id)
//        {
//            DeleteAsync(id).Wait();
//        }

//        public async Task<SearchResponse<T>> GetAsync(string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
//        {
//            var result = await _baseClient.SearchAsync(new Contact()
//            {
//                SearchTerm = search,
//                Page = pageNumber,
//                PageSize = pageSize,
//                Depth = depth.ToString()
//            });

//            //TODO: Fill out t
//            return new SearchResponse<T>();
//        }

//        public SearchResponse<T> Get(string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
//        {
//            return GetAsync(search, pageNumber, pageSize, depth).Result;
//        }

//        public SearchResponse<T> Get(int? id, string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
//        {
//            return GetAsync(id, search, pageNumber, pageSize, depth).Result;
//        }

//        public async Task<SearchResponse<T>> GetAsync(int? id, string search, int pageNumber, int pageSize, Depth depth = Depth.Complete)
//        {
//            return await _baseClient.SearchAsync(new T
//            {
//                Id = id,
//                SearchTerm = search,
//                Page = pageNumber,
//                PageSize = pageSize,
//                Depth = depth.ToString()
//            });
//        }
//    }

//}
