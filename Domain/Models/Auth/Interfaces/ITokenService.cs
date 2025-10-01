using Domain.Models.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth.Interfaces
{
    public interface ITokenService
    {
        TokenResponseDto GenerateToken(AuthClaimsData data);
    }
}
