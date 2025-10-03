using Application.DTOs.JWT;
using Application.DTOs.Login;
using Application.SecurityInterfaces;
using Domain.Models.Auth.Interfaces;

namespace Application.Services.StaffServices
{
    public sealed class StaffAuthService
    {
        private readonly IStaffAuthRepository _staffAuthRepository;
        private readonly ICredentialsAuthenticator _authenticator;
        private readonly ITokenService _tokenService;

        public StaffAuthService(
         IStaffAuthRepository staffAuthRepository,
         ICredentialsAuthenticator authenticator,
         ITokenService tokenService)
        {
            _staffAuthRepository = staffAuthRepository;
            _authenticator = authenticator;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var q = _staffAuthRepository.Query();

            var claims = await _authenticator.AuthenticateStaffAsync(q, dto.UsernameOrEmail, dto.Password);
            if (claims is null) return null;

            var token = _tokenService.GenerateToken(claims);
            return token;
        }
    }
}
