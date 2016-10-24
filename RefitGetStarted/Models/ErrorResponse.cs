using System.Net;
using Swashbuckle.Swagger;

namespace RefitGetStarted.Models
{
    public class ErrorResponse : Response
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}