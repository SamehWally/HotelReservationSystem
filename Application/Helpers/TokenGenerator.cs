using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace Application.Helpers
{
    public class TokenGenerator
    {
        public static string GenerateToken(int id, string userName, List<string> roles)
        {
            var key = Encoding.ASCII.GetBytes(Constant.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>
                {
                    new Claim("ID", id.ToString()),
                    new Claim(ClaimTypes.Name, userName)
                };

            // Add multiple roles as claims
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "HotelReservation",
                Audience = "HotelReservation-Front",
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
