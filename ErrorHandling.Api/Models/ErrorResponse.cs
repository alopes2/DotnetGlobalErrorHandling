using System.Net;
using System.Text.Json;

namespace ErrorHandling.Api.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

        public string Message { get; set; } = "An unexpected error occurred.";

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}