using System.ComponentModel.DataAnnotations;
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
    public class LoginResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("access_token")]
        public AccessToken AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public RefreshToken RefreshToken { get; set; }

        [JsonPropertyName("user_role")]
        public string UserRole { get; set; }
    }
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }

    public class MobileLoginRequest
    {
        [Required]
        [JsonPropertyName("idnumber")]
        public string IdNumber { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

    }

    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("idnumber")]
        public string IdNumber { get; set; }

        [Required]
        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("confirmpassword")]
        public string ConfirmPassword { get; set; }

        [Required]
        [JsonPropertyName("termsandconditions")]
        public bool TermsAndConditions { get; set; }
    }

    public class RegisterResult
    {

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public string UserName { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

    }

    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

    }

    public class ForgotPasswordResult
    {

        [JsonPropertyName("message")]
        public string Message { get; set; }

    }

    public class ResetPasswordRequest
    {
        [Required]
        [JsonPropertyName("guid")]
        public string guid { get; set; }

        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }


        [Required]
        [JsonPropertyName("newpassword")]
        public string NewPassword { get; set; }

        [Required]
        [JsonPropertyName("newconfirmpassword")]
        public string NewConfirmPassword { get; set; }
    }

    public class ResetPasswordResult
    {

        [JsonPropertyName("message")]
        public string Message { get; set; }

    }

    public class ActivateAccountRequest
    {
        [Required]
        [JsonPropertyName("guid")]
        public string guid { get; set; }
    }

    public class ActivateAccountResult
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
