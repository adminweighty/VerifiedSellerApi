using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VerifiedSeller.Shared.Entities.Remote.Request
{
    public class OptOutRequest
    {
        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }
    }
}
