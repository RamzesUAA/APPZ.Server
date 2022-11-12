using System.Net;

namespace APPZ.Core.Exceptions
{
    public class HttpCodeException: Exception
    {
        private HttpStatusCode _statusCode;
        public HttpStatusCode StatusCode { get => _statusCode; }
        public HttpCodeException(HttpStatusCode statusCode, string message)
            :base(message)
        {
            _statusCode = statusCode;
        }
        public HttpCodeException(HttpStatusCode statusCode)
            :this(statusCode, String.Empty)
        {

        }
    }
}
