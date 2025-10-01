namespace Presentation.ViewModels.Login
{
    public sealed class LoginRequestVM
    {
        public string UsernameOrEmail { get; init; } = default!;
        public string Password { get; init; } = default!;
    }
}
