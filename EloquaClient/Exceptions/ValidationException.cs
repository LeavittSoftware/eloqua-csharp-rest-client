using System;
using System.Net;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Exceptions
{
    public class ValidationException : Exception
    {
        public HttpStatusCode StatusCode;
        public string ErrorMessage;
        public string ResponseContent;
        public dynamic EloquaReponseObject;

       public ValidationException(IRestResponse response, dynamic eloquaReponseObject)
            : base(response.StatusCode.ToString())
        {
            StatusCode = response.StatusCode;
            ErrorMessage = response.ErrorMessage;
            ResponseContent = response.Content;
            EloquaReponseObject = eloquaReponseObject;
        }
    }
}
