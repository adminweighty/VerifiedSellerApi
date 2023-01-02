using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VerifiedSeller.Server.AuthenticationManager
{
    public interface IAuthManager
    {
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
        AuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
        AuthResult Refresh(string refreshToken, string accessToken, DateTime now);
        void RemoveExpiredRefreshTokens(DateTime now);
        void RemoveRefreshTokenByUserName(string userName);
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
    }
}
