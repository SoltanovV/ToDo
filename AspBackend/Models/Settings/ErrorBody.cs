using System.Text.Json;

namespace AspBackend.Models.Settings ;

    public class ErrorBody
    {
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }