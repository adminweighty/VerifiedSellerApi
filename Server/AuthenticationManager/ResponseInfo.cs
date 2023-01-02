using System.Text.Json.Serialization;

namespace VerifiedSeller.Server.AuthenticationManager
{
    public class ResponseInfo<T>
    {
        [JsonPropertyName("status")]
        public bool ResponseStatus { get; set; }
        [JsonPropertyName("message")]
        public string ResponseMessage { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("warnings")]
        public List<Warning> Warnings { get; set; }
        public Exception Exception { get; set; }

       
    }

    public class Warning
    {
        public string Code { get; set; }
        public string Text { get; set; }

    }
}
