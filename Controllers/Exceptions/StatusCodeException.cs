using System;
using System.Net;

namespace caffeServer.Controllers.Exceptions
{
    public class StatusCodeException : Exception
    {
        private HttpStatusCode _statusCode;
        public StatusCodeException(HttpStatusCode statusCode, string message)
            : base(message) 
        {
            _statusCode = statusCode;
        }
    }
}