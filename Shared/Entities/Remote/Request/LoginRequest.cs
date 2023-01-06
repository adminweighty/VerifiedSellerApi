using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VerifiedSeller.Shared.Entities.Remote.Request
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        public string Password { get; set; }

    }
}
