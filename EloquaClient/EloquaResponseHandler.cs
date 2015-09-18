using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
using LG.Eloqua.Api.Rest.ClientLibrary.Models.Errors;
using Newtonsoft.Json;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary
{
    public class EloquaResponseHandler
    {
        public static IRestResponse ErrorCheck(IRestResponse response)
        {
            switch (response.ResponseStatus)
            {
                case ResponseStatus.Completed:
                    {
                        switch (response.StatusCode)
                        {
                            case HttpStatusCode.OK:
                            case HttpStatusCode.Accepted:
                            case HttpStatusCode.Created:
                            case HttpStatusCode.Found:
                            case HttpStatusCode.NoContent:
                                return response;
                            case HttpStatusCode.NotFound:
                                {
                                    //Soft 404  
                                    if (string.IsNullOrWhiteSpace(response.Content))
                                        return response;
                                    throw new EloquaApiException(response);

                                }
                            case HttpStatusCode.Conflict:
                            case HttpStatusCode.BadRequest:
                                var validationErrors = JsonConvert.DeserializeObject<List<ObjectValidationError>>(response.Content);
                                throw new ValidationException(response, validationErrors);
                            default:
                                throw new EloquaApiException(response);
                        }
                    }

                case ResponseStatus.Aborted:
                case ResponseStatus.TimedOut:
                    throw new ConnectionErrorException(response);
                default:
                    throw new EloquaApiException(response);
            }
        }
    }
}
