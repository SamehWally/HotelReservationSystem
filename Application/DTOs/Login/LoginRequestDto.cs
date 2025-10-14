namespace Application.DTOs.Login
{
    public class LoginRequestDto
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
