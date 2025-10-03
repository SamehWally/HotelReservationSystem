namespace Domain.Models.Auth.Models
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public string Key { get; set; } = "";
        public int AccessTokenMinutes { get; set; } = 30;
    }
}
