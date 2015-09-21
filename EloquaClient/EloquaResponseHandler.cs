using System.Net;
using LG.Eloqua.Api.Rest.ClientLibrary.Exceptions;
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
                                var validationErrors = JsonConvert.DeserializeObject<dynamic>(response.Content);
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
