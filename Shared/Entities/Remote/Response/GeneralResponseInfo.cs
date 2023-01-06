using System.Text.Json.Serialization;

namespace VerifiedSeller.Shared.Entities.Remote.Response
{
    public class ResponseInfo
    {
        [JsonPropertyName("status")]
        public bool ResponseStatus { get; set; }
        [JsonPropertyName("message")]
        public string ResponseMessage { get; set; }
     
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("warnings")]
        public List<Warning> Warnings { get; set; }
      
      }

 
}
