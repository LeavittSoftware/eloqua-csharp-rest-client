using System;
using System.Net;
using System.Collections.Generic;
using Eloqua.Api.Rest.ClientLibrary.Exceptions;
using Eloqua.Api.Rest.ClientLibrary.Models.Errors;
using RestSharp;
using RestSharp.Deserializers;

namespace Eloqua.Api.Rest.ClientLibrary.Validation
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
