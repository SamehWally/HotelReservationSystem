namespace Presentation.ViewModels.JWT
{
    public sealed class TokenResponseVM
    {
        public string token_type { get; init; } = "Bearer";
        public string access_token { get; init; } = default!;
        public int expires_in { get; init; } 
    }

}
