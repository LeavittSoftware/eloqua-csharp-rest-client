using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Eloqua.Api.Rest.ClientLibrary.Models.Errors;
using RestSharp;

namespace Eloqua.Api.Rest.ClientLibrary.Exceptions
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
