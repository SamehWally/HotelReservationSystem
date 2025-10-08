namespace Domain.Models.Auth.Models
{
    public record AuthClaimsDataDto
    (
        int UserId,
        int? RoleId,
        string RoleName,
        IEnumerable<string> FeatureKeys,
        string? Username = null,
        string? Email = null,
        string? AccountType = null 
    );
}
