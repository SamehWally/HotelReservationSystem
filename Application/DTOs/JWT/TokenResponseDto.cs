namespace Application.DTOs.JWT
{
    public record TokenResponseDto(
        string AccessToken,
        DateTime ExpiresAt
    );

}
