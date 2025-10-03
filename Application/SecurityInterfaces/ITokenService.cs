using Application.DTOs.JWT;
using Domain.Models.Auth.Models;

namespace Domain.Models.Auth.Interfaces
{
    public interface ITokenService
    {
        TokenResponseDto GenerateToken(AuthClaimsDataDto data);
    }
}
