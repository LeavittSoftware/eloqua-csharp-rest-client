using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using JsonSerializer = LG.Eloqua.Api.Rest.ClientLibrary.RestSharp.Serializers.JsonSerializer;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    internal class Request
    {
        internal enum Type
        {
            Delete,
            Get,
            Post,
            Put,
            Search
        }

        internal static RestRequest Get(Type type, RestObject restObj)
        {
            restObj.Type = restObj.DeclaredType;
            var request = new RestRequest
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer(new Newtonsoft.Json.JsonSerializer
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };

            switch (type)
            {
                case Type.Get:
                    request.Method = Method.GET;
                    request.Resource = restObj.Uri + "/" + restObj.Id + "?depth=" + restObj.Depth;
                    break;

                case Type.Put:
                    request.Method = Method.PUT;
                    request.Resource = restObj.Uri + "/" + restObj.Id;
                    request.AddBody(restObj);
                    break;

                case Type.Post:
                    request.Method = Method.POST;
                    request.Resource = restObj.Uri + (restObj.Id != null ? "/" + restObj.Id : "");
                    request.AddBody(restObj);
                    break;

                case Type.Delete:
                    request.Method = Method.DELETE;
                    request.Resource = restObj.Uri + "/" + restObj.Id;
                    break;

                case Type.Search:
                    request.Method = Method.GET;

                    var resource = new StringBuilder(100);
                    resource.Append(restObj.Uri);

                    if (restObj.Id != null && restObj.Id > 0)
                    {
                        resource.Append("/" + restObj.Id);
                    }
                    else
                    {
                        resource.Append("s"); // pluralize the endpoint
                    }

                    var searchObj = restObj as ISearchable;
                    resource.Append("?search=" + searchObj.SearchTerm +
                                    "&count=" + searchObj.PageSize +
                                    "&page=" + searchObj.Page +
                                    "&depth=" + restObj.Depth
                                    );

                    request.Resource = resource.ToString();

                    break;

                default:
                    throw new NotSupportedException(type.ToString());
            }
            return request;
        }
    }
}
