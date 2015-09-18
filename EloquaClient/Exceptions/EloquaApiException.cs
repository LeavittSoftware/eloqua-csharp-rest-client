using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace LG.Eloqua.Api.Rest.ClientLibrary.Exceptions
{
    public class EloquaApiException : Exception
    {
        public HttpStatusCode StatusCode;
        public string ErrorMessage;
        public string ResponseContent;
        public EloquaApiException(IRestResponse response) : base(response.Content)
        {
            StatusCode = response.StatusCode;
            ErrorMessage = response.ErrorMessage;
            ResponseContent = response.Content;
        }

    }
}
