using System;
using System.Net;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Exceptions
{
    public class ConnectionErrorException : Exception
    {
        public HttpStatusCode StatusCode;
        public string ErrorMessage;
        public string ResponseContent;

        public ConnectionErrorException(IRestResponse response) : base(response.ErrorMessage)
        {
            StatusCode = response.StatusCode;
            ErrorMessage = response.ErrorMessage;
            ResponseContent = response.Content;
        }
    }
}
