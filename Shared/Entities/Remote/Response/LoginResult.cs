using System.Text.Json.Serialization;
using VerifiedSeller.Server.AuthenticationManager;

namespace VerifiedSeller.Shared.Entities.Remote.Response
{
    public class LoginResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_email")]
        public string Email { get; set; }

        [JsonPropertyName("buyer_type")]
        public string Buyer { get; set; }

        [JsonPropertyName("mobile_number")]
        public string Mobile { get; set; }

          [JsonPropertyName("access_token")]
        public AccessToken AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public RefreshToken RefreshToken { get; set; }

        [JsonPropertyName("user_role")]
        public string UserRole { get; set; }
    }
}
