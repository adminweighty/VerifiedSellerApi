using System.Text.Json.Serialization;

namespace VerifiedSeller.Server.AuthenticationManager
{
    public class AuthResult
    {
        [JsonPropertyName("accessToken")]
        public AccessToken AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }

    public class AccessToken
    {
        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }

    public class RefreshToken
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }    // can be used for usage tracking
        // can optionally include other metadata, such as user agent, ip address, device name, and so on

        [JsonPropertyName("tokenString")]
        public string TokenString { get; set; }

        [JsonPropertyName("expireAt")]
        public DateTime ExpireAt { get; set; }
    }
    public class AuthTokenConfig
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }
    }
    

    

    

    
}
