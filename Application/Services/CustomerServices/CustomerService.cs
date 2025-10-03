using Application.DTOs.JWT;
using Application.DTOs.Login;
using Application.SecurityInterfaces;
using Domain.Models.Auth.Interfaces;
using Domain.Repositories;

namespace Application.Services.CustomerServices
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICredentialsAuthenticator _authenticator;
        private readonly ITokenService _tokenService;

        public CustomerService(
         ICustomerRepository customerRepository,
         ICredentialsAuthenticator authenticator,
         ITokenService tokenService)
        {
            _customerRepository = customerRepository;
            _authenticator = authenticator;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var q = _customerRepository.Query();

            var claims = await _authenticator.AuthenticateCustomerAsync(q, dto.UsernameOrEmail, dto.Password);
            if (claims is null) return null;

            var token = _tokenService.GenerateToken(claims);
            return token;
        }
    }
}
