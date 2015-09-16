using System;
using System.Collections.Generic;
using System.Net;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Errors;
using RestSharp;
using RestSharp.Deserializers;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Validation
{
    public class ResponseValidator
    {
        internal static Exception GetExceptionFromResponse(IRestResponse response)
        {
            var jsonDeserializer = new JsonDeserializer();

            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    return new ValidationException(response, jsonDeserializer.Deserialize<List<ObjectValidationError>>(response));

                default:
                    return new ValidationException(response);
            }
        }
    }
}
