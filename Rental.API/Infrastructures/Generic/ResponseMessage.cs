using System.Net;

namespace Rental.API.Infrastructures.Generic
{
    public class ResponseMessage<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string StatusName { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
