using System;
using System.Net;

namespace ErrorHandling.Api.Models
{
    public class HttpErrorException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpErrorException(HttpStatusCode statusCode, string message)
            : base(message)
        { 
            StatusCode = statusCode;
        }
    }
}