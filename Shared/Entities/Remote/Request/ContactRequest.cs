using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VerifiedSeller.Shared.Entities.Remote.Request
{
    public class ContactRequest
    {
        [Required]
        [JsonPropertyName("Fullnames")]
        public string Fullnames { get; set; }

        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("Message")]
        public string Message { get; set; }
    }
}
