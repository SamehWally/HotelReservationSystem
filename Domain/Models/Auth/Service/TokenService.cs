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

namespace Domain.Models.Auth.Service
{
    public class TokenService
    {
        private readonly JwtOptions _opt;
        private readonly byte[] _keyBytes;

        public TokenService(IOptions<JwtOptions> opt)
        {
            _opt = opt.Value;
            _keyBytes = Encoding.ASCII.GetBytes(_opt.Key);
        }

        public TokenResult GenerateToken(AuthClaimsData data)
        {
            var now = DateTime.UtcNow;
            var expires = now.AddMinutes(_opt.AccessTokenMinutes);

            var claims = new List<Claim>
            {
                    new(JwtRegisteredClaimNames.Sub, data.UserId.ToString()),
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new("uid", data.UserId.ToString()),
                    new("roleId", data.RoleId.ToString()),
                    new(ClaimTypes.Role, data.RoleName ?? string.Empty),
            };

            if (!string.IsNullOrWhiteSpace(data.Username))
                claims.Add(new(ClaimTypes.Name, data.Username!));

            if (!string.IsNullOrWhiteSpace(data.Email))
                claims.Add(new(JwtRegisteredClaimNames.Email, data.Email!));

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
                Issuer = _opt.Issuer,
                Audience = _opt.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_keyBytes),
                    SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(descriptor);
            var accessToken = tokenHandler.WriteToken(token);
            return new TokenResult(accessToken, expires);
        }
    }
}
