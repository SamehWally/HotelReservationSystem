using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth.Models
{
    public record AuthClaimsData
    (
        int UserId,
        int? RoleId,
        string RoleName,
        IEnumerable<string> FeatureKeys,
        string? Username = null,
        string? Email = null,
        string? AccountType = null 
    );
    public record TokenResponseDto(string AccessToken, DateTime ExpiresAt);
}
