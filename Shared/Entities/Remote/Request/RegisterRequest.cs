using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VerifiedSeller.Shared.Entities.Remote.Request
{
    public class RegisterRequest
    {
        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("Buyer")]
        public string Buyer { get; set; }

        [Required]
        [JsonPropertyName("MobileNumber")]
        public string MobileNumber { get; set; }

        [Required]
        [JsonPropertyName("Platform")]
        public string Platform { get; set; }
    }
}
