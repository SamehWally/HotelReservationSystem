using Application.DTOs.JWT;
using Application.DTOs.Login;
using Application.SecurityInterfaces;
using Domain.Models.Auth.Interfaces;
using Domain.Repositories.CustomerInterfaces;

namespace Application.Services.CustomerServices
{
    public class CustomerAuthService
    {
        private readonly ICustomerAuthRepository _customerAuthRepository;
        private readonly ICredentialsAuthenticator _authenticator;
        private readonly ITokenService _tokenService;

        public CustomerAuthService(
         ICustomerAuthRepository customerAuthRepository,
         ICredentialsAuthenticator authenticator,
         ITokenService tokenService)
        {
            _customerAuthRepository = customerAuthRepository;
            _authenticator = authenticator;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var q = _customerAuthRepository.Query();

            var claims = await _authenticator.AuthenticateCustomerAsync(q, dto.UsernameOrEmail, dto.Password);
            if (claims is null) return null;

            var token = _tokenService.GenerateToken(claims);
            return token;
        }
    }
}
