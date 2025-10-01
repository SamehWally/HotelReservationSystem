using Domain.Models.Auth.Interfaces;
using Domain.Models.Auth.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _opt;
        private readonly byte[] _keyBytes;

        public TokenService(IOptions<JwtOptions> opt)
        {
            _opt = opt.Value;

            if (string.IsNullOrWhiteSpace(_opt.Key))
                throw new InvalidOperationException("JWT Key is missing.");

            _keyBytes = Encoding.UTF8.GetBytes(_opt.Key);
            if (_keyBytes.Length < 32)
                throw new InvalidOperationException("JWT key too short. Use at least 32 bytes for HS256.");
        }

        public TokenResponseDto GenerateToken(AuthClaimsData data)
        {
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_opt.AccessTokenMinutes);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, data.UserId.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new("uid", data.UserId.ToString()),
                new(ClaimTypes.NameIdentifier, data.UserId.ToString()),
            };

            if (data.RoleId.HasValue)
                claims.Add(new("roleId", data.RoleId.Value.ToString()));

            if (!string.IsNullOrWhiteSpace(data.RoleName))
                claims.Add(new(ClaimTypes.Role, data.RoleName));

            if (!string.IsNullOrWhiteSpace(data.Username))
                claims.Add(new(ClaimTypes.Name, data.Username));

            if (!string.IsNullOrWhiteSpace(data.Email))
                claims.Add(new(JwtRegisteredClaimNames.Email, data.Email));

            if (!string.IsNullOrWhiteSpace(data.AccountType))
                claims.Add(new("acc", data.AccountType)); // "customer", "staff"

            foreach (var key in (data.FeatureKeys ?? Enumerable.Empty<string>())
                                 .Where(k => !string.IsNullOrWhiteSpace(k))
                                 .Select(k => k.Trim())
                                 .Distinct(StringComparer.OrdinalIgnoreCase))
            {
                claims.Add(new("perm", key));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = now,
                Expires = expires,
                Issuer = string.IsNullOrWhiteSpace(_opt.Issuer) ? null : _opt.Issuer,
                Audience = string.IsNullOrWhiteSpace(_opt.Audience) ? null : _opt.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_keyBytes),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);
            var accessToken = tokenHandler.WriteToken(token);
            return new TokenResponseDto(accessToken, expires);
        }
    }
}
